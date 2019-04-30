using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Logger;
using Lacey.Medusa.Instagram.Api.Extensions;
using Microsoft.Extensions.Logging;
using LogLevel = InstagramApiSharp.Logger.LogLevel;

namespace Lacey.Medusa.Instagram.Api.Services.Concrete
{
    public class InstagramProvider : IInstagramProvider
    {

        #region Fields/Constructors

        private readonly IInstagramAuthProvider instagramAuthProvider;

        private readonly ILogger logger;

        private readonly string instagramStateFilePath;

        public InstagramProvider(
            IInstagramAuthProvider instagramAuthProvider,
            ILogger<InstagramProvider> logger, 
            string instagramStateFilePath)
        {
            this.instagramAuthProvider = instagramAuthProvider;
            this.logger = logger;
            this.instagramStateFilePath = instagramStateFilePath;
        }

        protected IInstaApi Instagram { get; set; }

        #endregion

        #region Login

        public async Task Login()
        {
            var userSession = instagramAuthProvider.GetUserSessionData();
            var delay = RequestDelay.FromSeconds(2, 2);
            this.Instagram = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.Info))
                .SetRequestDelay(delay)
                .Build();

            var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var stateFile = Path.Combine(currentFolder, this.instagramStateFilePath);
            try
            {
                if (File.Exists(stateFile))
                {
                    Console.WriteLine("Loading state from file.");
                    using (var fs = File.OpenRead(stateFile))
                    {
                        this.Instagram.LoadStateDataFromString(new StreamReader(fs).ReadToEnd());
                    }
                }
            }
            catch (Exception e)
            {
                this.logger.LogTrace(e.ToString());
            }

            if (!this.Instagram.IsUserAuthenticated)
            {
                this.logger.LogTrace($"Logging in as {userSession.UserName}");
                delay.Disable();
                var logInResult = await this.Instagram.LoginAsync();
                delay.Enable();
                if (!logInResult.Succeeded)
                {
                    if (logInResult.Value == InstaLoginResult.ChallengeRequired)
                    {
                        var challenge = await this.Instagram.GetChallengeRequireVerifyMethodAsync();
                        if (challenge.Succeeded)
                        {
                            var request = await this.Instagram.RequestVerifyCodeToEmailForChallengeRequireAsync();
                            if (request.Succeeded)
                            {
                                var code = File.ReadAllLines(Path.Combine(currentFolder, "code.secret"))[0];
                                var verifyLogin = await this.Instagram.VerifyCodeForChallengeRequireAsync(code);
                                if (verifyLogin.Succeeded)
                                {
                                    var s = this.Instagram.GetStateDataAsString();
                                    File.WriteAllText(stateFile, s);
                                    throw new Exception("Login state saved. Please try again later.");
                                }
                            }
                        }
                    }
                    else
                        this.logger.LogTrace($"Unable to login: {logInResult.Info.Message}");
                }
            }

            var state = this.Instagram.GetStateDataAsString();
            File.WriteAllText(stateFile, state);
        }


        #endregion

        #region Apply metadata

        public async Task<IResult<bool>> UnArchiveMediaAsync(string mediaId)
        {
            return await this.Instagram.MediaProcessor.UnArchiveMediaAsync(mediaId);
        }

        public async Task<IResult<bool>> UnSaveMediaAsync(string mediaId)
        {
            return await this.Instagram.MediaProcessor.UnSaveMediaAsync(mediaId);
        }

        public async Task<IResult<InstaMedia>> EditMediaAsync(
            string mediaId,
            string caption,
            InstaLocationShort location = null,
            InstaUserTagUpload[] userTags = null)
        {
            return await this.Instagram.MediaProcessor.EditMediaAsync(
                mediaId,
                caption,
                location,
                userTags);
        }

        #endregion

        #region Transfer media

        public async Task<InstaMediaList> GetUserMediaLast(string userName)
        {
            var userMedia = await this.Instagram.UserProcessor.GetUserMediaAsync(
                userName, PaginationParameters.MaxPagesToLoad(3));

            return userMedia.Value;
        }

        public async Task<InstaMediaList> GetUserMediaAll(string userName)
        {
            var userMedia = await this.Instagram.UserProcessor.GetUserMediaAsync(
//                userName, PaginationParameters.MaxPagesToLoad(int.MaxValue));
                userName, PaginationParameters.MaxPagesToLoad(3));

            return userMedia.Value;
        }

        public async Task<string> DownloadMedia(InstaMedia media, string outputFolder)
        {
            using (var client = new WebClient())
            {
                Directory.CreateDirectory(outputFolder);
                var image = media.GetImages().FirstOrDefault();
                if (image != null)
                {
                    var outputFilePath = Path.Combine(outputFolder, $"{media.Code}.jpg");
                    client.DownloadFile(image.Uri, outputFilePath);
                    return outputFilePath;
                }
            }

            return null;
        }

        public async Task<IReadOnlyList<IResult<InstaMedia>>> UploadMedia(InstaMedia media, string outputFolder)
        {
            var images = new List<InstaImageUpload>();
            var albumImages = new List<InstaImageUpload>();
//            var videos = new List<InstaVideoUpload>();
            var files = new List<string>();

            using (var client = new WebClient())
            {
                Directory.CreateDirectory(outputFolder);
                foreach (var image in media.GetImages())
                {
                    var outputFilePath = Path.Combine(outputFolder, $"IMG-{Guid.NewGuid()}.jpg");
                    client.DownloadFile(image.Uri, outputFilePath);
                    files.Add(outputFilePath);
                    images.Add(image.AsUpload(media, outputFilePath));
                }

                foreach (var image in media.GetAlbumImages())
                {
                    var outputFilePath = Path.Combine(outputFolder, $"IMG-{Guid.NewGuid()}.jpg");
                    client.DownloadFile(image.Uri, outputFilePath);
                    files.Add(outputFilePath);
                    albumImages.Add(image.AsUpload(media, outputFilePath));
                }

                /*
                foreach (var video in media.GetOriginalVideos())
                {
                    var outputFilePath = Path.Combine(outputFolder, $"VID-{Guid.NewGuid()}.mp4");
                    client.DownloadFile(video.Uri, outputFilePath);
                    files.Add(outputFilePath);
                    videos.Add(video.AsUpload(outputFilePath));
                }
                */
            }

            var results = new List<IResult<InstaMedia>>();
            var caption = media.Caption?.Text;
            var location = media.Location;

            foreach (var image in images)
            {
                try
                {
                    results.Add(await this.Instagram.MediaProcessor.UploadPhotoAsync(
                        this.UploadProgress,
                        image,
                        caption,
                        location));
                }
                catch (Exception e)
                {
                    this.logger.LogTrace(e.Message);
                }
            }

            if (albumImages.Any())
            {
                try
                {
                    results.Add(await this.Instagram.MediaProcessor.UploadAlbumAsync(
                        albumImages.ToArray(),
                        null,
                        caption,
                        location));
                }
                catch (Exception e)
                {
                    this.logger.LogTrace(e.Message);
                }
            }

            /*foreach (var video in videos)
            {
                try
                {
                    results.Add(await this.Instagram.MediaProcessor.UploadVideoAsync(
                        this.UploadProgress,
                        video,
                        caption,
                        location));
                }
                catch (Exception e)
                {
                    this.logger.LogTrace(e.Message);
                }
            }*/

            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }

            return results;
        }

        private void UploadProgress(InstaUploaderProgress progress)
        {
            if (progress == null)
                return;
            this.logger.LogTrace($"{progress.Name} {progress.UploadState}");
        }

        #endregion
    }
}