using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Logger;
using Microsoft.Extensions.Logging;
using LogLevel = InstagramApiSharp.Logger.LogLevel;

namespace Lacey.Medusa.Instagram.Api.Services.Concrete
{
    public sealed class InstagramProvider : IInstagramProvider
    {

        #region Fields/Constructors

        private readonly IInstaApi instagram;

        private readonly ILogger logger;

        public InstagramProvider(
            IInstagramAuthProvider instagramAuthProvider,
            ILogger<InstagramProvider> logger)
        {
            this.logger = logger;

            var userSession = instagramAuthProvider.GetUserSessionData();
            var delay = RequestDelay.FromSeconds(2, 2);
            this.instagram = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.Info))
                .SetRequestDelay(delay)
                .Build();

            var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var stateFile = Path.Combine(currentFolder, "state.bin");
            try
            {
                if (File.Exists(stateFile))
                {
                    this.logger.LogTrace("Loading state from file.");
                    using (var fs = File.OpenRead(stateFile))
                    {
                        this.instagram.LoadStateDataFromString(new StreamReader(fs).ReadToEnd());
                    }
                }
            }
            catch (Exception e)
            {
                this.logger.LogTrace(e.ToString());
            }

            if (!this.instagram.IsUserAuthenticated)
            {
                this.logger.LogTrace($"Logging in as {userSession.UserName}");
                delay.Disable();
                var logInResult = this.instagram.LoginAsync().Result;
                delay.Enable();
                if (!logInResult.Succeeded)
                {
                    this.logger.LogTrace($"Unable to login: {logInResult.Info.Message}");
                }
            }

            var state = this.instagram.GetStateDataAsString();
            File.WriteAllText(stateFile, state);
        }

        #endregion

        #region Media

        public async Task<InstaMediaList> GetUserMediaAll(string userName)
        {
            var userMedia = await this.instagram.UserProcessor.GetUserMediaAsync(
                userName, PaginationParameters.MaxPagesToLoad(1));

            return userMedia.Value;
        }

        public async Task<IResult<InstaMedia>> UploadMedia(InstaMedia media, string outputFolder)
        {
            var images = new List<InstaImageUpload>();
            var videos = new List<InstaVideoUpload>();
            var files = new List<string>();

            using (var client = new WebClient())
            {
                Directory.CreateDirectory(outputFolder);
                if (media.Images != null)
                {
                    foreach (var image in media.Images)
                    {
                        var outputFilePath = Path.Combine(outputFolder, $"IMG-{Guid.NewGuid()}.jpg");
                        client.DownloadFile(image.Uri, outputFilePath);
                        files.Add(outputFilePath);

                        var imageUpload = new InstaImageUpload(outputFilePath, image.Width, image.Height);
                        var tagsUpload = new List<InstaUserTagUpload>();
                        if (media.UserTags != null)
                        {
                            foreach (var tag in media.UserTags)
                            {
                                var tagUpload = new InstaUserTagUpload();
                                if (tag.User != null)
                                {
                                    tagUpload.Username = tag.User.UserName;
                                }

                                if (tag.Position != null)
                                {
                                    tagUpload.X = tag.Position.X;
                                    tagUpload.Y = tag.Position.Y;
                                }

                                tagsUpload.Add(tagUpload);
                            }
                        }
                        imageUpload.UserTags.AddRange(tagsUpload);
                        images.Add(imageUpload);
                    }
                }

                if (media.Videos != null)
                {
                    foreach (var video in media.Videos)
                    {
                        var outputFilePath = Path.Combine(outputFolder, $"VID-{Guid.NewGuid()}.mp4");
                        client.DownloadFile(video.Uri, outputFilePath);
                        video.VideoBytes = File.ReadAllBytes(outputFilePath);
                        files.Add(outputFilePath);

                        var thumbnail = new InstaImage();
                        var videoUpload = new InstaVideoUpload(video, thumbnail);
                        videos.Add(videoUpload);
                    }
                }
            }

            IResult<InstaMedia> result = null;
            try
            {
                result = await this.instagram.MediaProcessor.UploadAlbumAsync(this.UploadProgress,
                    images.ToArray(),
                    videos.ToArray(),
                    media.Caption?.Text,
                    media.Location);
            }
            catch (Exception e)
            {
                this.logger.LogTrace(e.Message);
            }
            finally
            {
                foreach (var file in files)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            }

            return result;
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