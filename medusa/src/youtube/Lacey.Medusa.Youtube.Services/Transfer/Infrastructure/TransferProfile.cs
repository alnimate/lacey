using AutoMapper;
using Lacey.Medusa.Youtube.Common.Models;
using Lacey.Medusa.Youtube.Services.Transfer.Models.Download;

namespace Lacey.Medusa.Youtube.Services.Transfer.Infrastructure
{
    public class TransferProfile : Profile
    {
        public TransferProfile()
        {
            // Youtube => Download
            this.CreateMap<YoutubeVideo, DownloadVideo>()
                .ConstructUsing(y => new DownloadVideo(
                    y.VideoId,
                    y.Title,
                    y.Description,
                    y.PublishedAt));

            this.CreateMap<YoutubeChannel, DownloadChannelInfo>()
                .ConstructUsing(y => new DownloadChannelInfo(
                    y.ChannelId,
                    y.Title,
                    y.Description));
        }
    }
}