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
using Lacey.Medusa.Instagram.Api.Extensions;
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
                userName, PaginationParameters.MaxPagesToLoad(int.MaxValue));

            return userMedia.Value;
        }

        public async Task<IReadOnlyList<IResult<InstaMedia>>> UploadMedia(InstaMedia media, string outputFolder)
        {
            var images = new List<InstaImageUpload>();
            var videos = new List<InstaVideoUpload>();
            var files = new List<string>();

            using (var client = new WebClient())
            {
                Directory.CreateDirectory(outputFolder);
                foreach (var image in media.GetOriginalImages())
                {
                    var outputFilePath = Path.Combine(outputFolder, $"IMG-{Guid.NewGuid()}.jpg");
                    client.DownloadFile(image.Uri, outputFilePath);
                    files.Add(outputFilePath);
                    images.Add(image.AsUpload(media, outputFilePath));
                }

                foreach (var video in media.GetOriginalVideos())
                {
                    var outputFilePath = Path.Combine(outputFolder, $"VID-{Guid.NewGuid()}.mp4");
                    client.DownloadFile(video.Uri, outputFilePath);
                    files.Add(outputFilePath);
                    videos.Add(video.AsUpload(outputFilePath));
                }
            }

            var results = new List<IResult<InstaMedia>>();
            var caption = media.Caption?.Text;
            var location = media.Location;

            foreach (var image in images)
            {
                try
                {
                    results.Add(await this.instagram.MediaProcessor.UploadPhotoAsync(
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

            foreach (var video in videos)
            {
                try
                {
                    results.Add(await this.instagram.MediaProcessor.UploadVideoAsync(
                        this.UploadProgress,
                        video,
                        caption,
                        location));
                }
                catch (Exception e)
                {
                    this.logger.LogTrace(e.Message);
                }
            }

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