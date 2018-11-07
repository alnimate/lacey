namespace Lacey.Medusa.Youtube.Services.Transfer.Models.Download
{
    public sealed class DownloadChannelInfo
    {
        public DownloadChannelInfo(
            string channelId, 
            string title, 
            string description)
        {
            ChannelId = channelId;
            Title = title;
            Description = description;
        }

        public string ChannelId { get; }

        public string Title { get; }

        public string Description { get; }
    }
}