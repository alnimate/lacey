using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Lacey.Medusa.Common.Api.Base.Upload;
using Lacey.Medusa.Youtube.Api.Base;
using Lacey.Medusa.Youtube.Api.Services.Auth;
using Lacey.Medusa.Youtube.Api.Services.Common;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Common.Models.Videos;

namespace Lacey.Medusa.Youtube.Api.Services.Channels
{
    public sealed class YoutubeUploadVideoApiProvider : YoutubeApiService, IYoutubeUploadVideoProvider
    {
        public YoutubeUploadVideoApiProvider(IYoutubeAuthProvider youtubeAuthProvider, IMapper mapper) : base(youtubeAuthProvider, mapper)
        {
        }

        public async Task UploadVideo(
            string channelId, 
            YoutubeVideo youtubeVideo,
            string filePath)
        {
            var video = this.Mapper.Map<Video>(youtubeVideo);
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = this.Youtube.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += OnProgressChanged;
                videosInsertRequest.ResponseReceived += OnResponseReceived;

                await videosInsertRequest.UploadAsync();
            }
        }

        private void OnProgressChanged(IUploadProgress obj)
        {            
        }


        private void OnResponseReceived(Video obj)
        {
        }
    }
}