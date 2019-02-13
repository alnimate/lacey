using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Boost.Services.Const;
using Lacey.Medusa.Boost.Services.Extensions;
using Lacey.Medusa.Common.Browser.Browsers;
using Lacey.Medusa.Common.Browser.Extensions;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Extensions;
using Lacey.Medusa.Youtube.Api.Models.Const;
using Lacey.Medusa.Youtube.Api.Models.Enums;
using Lacey.Medusa.Youtube.Api.Services;
using Lacey.Medusa.Youtube.Api.Services.Concrete;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;

namespace Lacey.Medusa.Boost.Services.Services.Concrete
{
    public sealed class YoutubeBoostProvider : YoutubeProvider, IYoutubeBoostProvider
    {
        private readonly ILogger logger;

        private ChromeBrowser browser;

        public YoutubeBoostProvider(
            IYoutubeAuthProvider youtubeAuthProvider,
            ILogger<YoutubeBoostProvider> logger) 
            : base(youtubeAuthProvider, logger)
        {
            this.logger = logger;
        }

        public void EnableBrowser()
        {
            this.browser = new ChromeBrowser();
        }

        public async Task<CommentThread> AddComment(
            string channelId, 
            string videoId, 
            string text)
        {
            var comment = new CommentThread();
            var snippet = new CommentThreadSnippet
            {
                ChannelId = channelId,
                VideoId = videoId,
                TopLevelComment = new Comment
                {
                    Snippet = new CommentSnippet
                    {
                        TextOriginal = text
                    }
                }
            };
            comment.Snippet = snippet;

            var request = this.Youtube.CommentThreads.Insert(comment, CommentParts.Snippet);
            var response = await request.ExecuteAsync();

            return response;
        }

        public async Task<IReadOnlyList<SearchResult>> FindVideosByTags(string[] tags, long maxResults)
        {
            var request = this.Youtube.Search.List(VideoParts.Snippet);
            request.Q = tags.ToQuery();
            request.Order = SearchResource.ListRequest.OrderEnum.Date;
            request.RegionCode = CountryCodes.Us;
            request.RelevanceLanguage = Language.Us;
            request.Type = ResourceType.Video;
            request.MaxResults = maxResults;

            var response = await request.ExecuteAsync();
            var videos = response.Items.Where(i => i.Id.Kind == ResourceKind.Video).ToList();

            return videos;
        }

        public async Task<Video> GetVideo(string videoId)
        {
            var request = this.Youtube.Videos.List(VideoParts.AllAnonymous.AsListParam());
            request.Id = videoId;
            request.MaxResults = 1;

            var response = await request.ExecuteAsync();

            return response.Items.First();
        }

        public bool AddCommentManually(string videoId, string text)
        {
            if (this.browser == null)
            {
                return false;
            }

            try
            {
                browser.Driver.Navigate().GoToUrl($"{YoutubeConst.YoutubeVideoUrl}{videoId}");

                const int timeout = 20;
                var comment = browser.Driver.WaitUntilElementVisible(
                    By.Id("simplebox-placeholder"),
                    timeout);
                if (comment == null)
                {
                    return false;
                }

                comment.Click();
                comment = browser.Driver.WaitUntilElementVisible(
                    By.Id("contenteditable-textarea"),
                    timeout);

                if (comment == null)
                {
                    return false;
                }
                comment.SendKeys(text.RemoveEmoji());

                var button = browser.Driver.WaitUntilElementVisible(
                    By.Id("submit-button"),
                    timeout);

                if (button == null)
                {
                    return false;
                }

                button.Click();

                return true;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
            }

            return false;
        }

        public void Dispose()
        {
            browser?.Dispose();
        }
    }
}