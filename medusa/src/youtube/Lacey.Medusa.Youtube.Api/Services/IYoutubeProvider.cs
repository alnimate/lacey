using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Youtube.Api.Services
{
    public interface IYoutubeProvider
    {
        Task<Channel> GetChannel(string channelId);

        Task<Channel> UpdateChannelMetadata(string channelId, Channel channel);

        Task<IList<Playlist>> GetPlaylists(string channelId);

        Task<IList<Playlist>> UploadPlaylists(string channelId, IList<Playlist> playlists);

        Task<IList<Subscription>> GetSubscriptions(string channelId);

        Task<IList<Subscription>> UploadSubscriptions(string channelId, IList<Subscription> subscriptions);

        Task<IList<CommentThread>> GetChannelComments(string channelId);

        Task<IList<CommentThread>> UploadChannelComments(string channelId, IList<CommentThread> comments);

        Task<IReadOnlyList<Base.Video>> GetChannelVideos(string channelId);

        Task<string> DownloadVideo(string videoId);

        Task<Base.Video> UploadVideo(string channelId, Base.Video video, string filePath);
    }
}