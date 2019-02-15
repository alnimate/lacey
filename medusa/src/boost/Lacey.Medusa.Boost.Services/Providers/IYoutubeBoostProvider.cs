using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Boost.Services.Providers
{
    public interface IYoutubeBoostProvider : IDisposable
    {
        Task<IReadOnlyList<SearchResult>> FindVideos(string query, long maxResults);

        Task<Video> GetVideo(string videoId);

        Task<CommentThread> AddComment(
            string channelId,
            string videoId,
            string text);

        #region Manual actions

        bool AddCommentManually(
            string videoId,
            string text);

        void EnableBrowser();

        #endregion
    }
}