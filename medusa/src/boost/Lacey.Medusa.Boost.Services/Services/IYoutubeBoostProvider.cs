using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Boost.Services.Services
{
    public interface IYoutubeBoostProvider : IDisposable
    {
        Task<IReadOnlyList<SearchResult>> FindVideosByTags(string[] tags, long maxResults);

        Task<Video> GetVideo(string videoId);

        Task<CommentThread> AddComment(
            string channelId,
            string videoId,
            string text);

        bool AddCommentManually(
            string videoId,
            string text);

        void EnableBrowser();
    }
}