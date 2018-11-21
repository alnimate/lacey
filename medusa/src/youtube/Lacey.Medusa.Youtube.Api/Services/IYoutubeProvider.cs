using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Youtube.Api.Services
{
    public interface IYoutubeProvider
    {
        #region videos

        Task<IReadOnlyList<Base.Video>> GetVideos(string channelId);

        Task<IReadOnlyList<string>> GetVideoIds(string channelId);

        Task<string> DownloadVideo(string videoId, string outputFolder);

        Task<Base.Video> UploadVideo(string channelId, Base.Video video, string filePath);

        Task<string> DeleteVideo(string videoId);

        #endregion

        #region playlists

        Task<IList<Playlist>> GetPlaylists(string channelId);

        Task<IList<Playlist>> UploadPlaylists(string channelId, IList<Playlist> playlists);

        Task DeletePlaylists(string channelId);

        #endregion

        #region subscriptions

        Task<IList<Subscription>> GetSubscriptions(string channelId);

        Task<IList<Subscription>> UploadSubscriptions(string channelId, IList<Subscription> subscriptions);

        Task DeleteSubscriptions(string channelId);

        #endregion

        #region comments

        Task<IList<CommentThread>> GetComments(string channelId);

        Task<IList<CommentThread>> UploadComments(string channelId, IList<CommentThread> comments);

        Task DeleteComments(string channelId);

        #endregion

        #region metadata

        Task<Channel> GetChannel(string channelId);

        Task<Channel> UpdateMetadata(string channelId, Channel channel);

        Task DeleteMetadata(string channelId);

        Task<string> DownloadIcon(Channel channel, string outputFolder);

        #endregion
    }
}