using System.Collections.Generic;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Youtube.Api.Services
{
    public interface IYoutubeProvider
    {
        #region get videos

        Task<IReadOnlyList<string>> GetVideoIdsLast(string channelId);

        Task<IReadOnlyList<Base.Video>> GetVideosLast(string channelId);

        Task<IReadOnlyList<Base.Video>> GetVideos(IReadOnlyList<string> videosIds);

        Task<IReadOnlyList<Base.Video>> GetVideos(string channelId);

        Task<IReadOnlyList<string>> GetVideoIds(string channelId);

        #endregion

        #region download video

        Task<string> DownloadVideo(string videoId, string outputFolder);

        #endregion

        #region update video

        Task<Base.Video> UploadVideo(string channelId, Base.Video video, string filePath);

        Task UploadThumbnail(string videoId, string imageUrl);

        Task<Base.Video> UpdateVideoDescription(
            Base.Video video,
            string oldPhrase,
            string newPhrase);

        #endregion

        #region delete video

        Task<string> DeleteVideo(string videoId);

        #endregion

        #region playlists

        Task<IList<Playlist>> GetPlaylists(string channelId);
            
        Task<Playlist> UploadPlaylist(string channelId, Playlist playlist);

        Task DeletePlaylists(string channelId);

        #endregion

        #region playlist items

        Task<IList<PlaylistItem>> GetPlaylistItems(string playlistId);

        Task<PlaylistItem> UploadPlaylistItem(string channelId, string playlistId, PlaylistItem playlistItem);

        Task DeletePlaylistItems(string playlistId);

        #endregion

        #region sections

        Task<IList<ChannelSection>> GetSections(string channelId);

        Task<IList<ChannelSection>> UploadSections(string channelId, IList<ChannelSection> sections);

        Task DeleteSections(string channelId);

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