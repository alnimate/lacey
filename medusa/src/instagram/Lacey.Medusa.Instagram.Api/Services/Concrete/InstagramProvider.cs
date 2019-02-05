using System;
using System.IO;
using System.Net;
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
        }

        public async Task<InstaMediaList> GetUserMediaAsync(string userName)
        {
            var currentUserMedia = await this.instagram.UserProcessor.GetUserMediaAsync(
                userName, PaginationParameters.MaxPagesToLoad(1));

            return currentUserMedia.Value;
        }

        public async Task DownloadMedia(InstaMedia media, string outputFolder)
        {
            Directory.CreateDirectory(outputFolder);
            if (media.Images != null)
            {
                foreach (var image in media.Images)
                {
                    var outputFilePath = Path.Combine(outputFolder, $"IMG-{Guid.NewGuid()}.jpg");
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(image.Uri, outputFilePath);
                    }
                }
            }

            if (media.Videos != null)
            {
                foreach (var video in media.Videos)
                {
                    var outputFilePath = Path.Combine(outputFolder, $"VID-{Guid.NewGuid()}.mp4");
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(video.Uri, outputFilePath);
                    }
                }
            }
        }
    }
}