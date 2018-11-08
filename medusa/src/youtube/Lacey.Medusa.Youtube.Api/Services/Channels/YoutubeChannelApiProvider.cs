using System.Linq;
using System.Threading.Tasks;
using Lacey.Medusa.Youtube.Api.Services.Auth;
using Lacey.Medusa.Youtube.Api.Services.Common;
using Lacey.Medusa.Youtube.Common.Interfaces;
using Lacey.Medusa.Youtube.Common.Models;

namespace Lacey.Medusa.Youtube.Api.Services.Channels
{
    public sealed class YoutubeChannelApiProvider : YoutubeApiService, IYoutubeChannelProvider
    {
        public YoutubeChannelApiProvider(IYoutubeAuthProvider youtubeAuthProvider) : 
            base(youtubeAuthProvider)
        {
        }

        public async Task<YoutubeChannel> GetYoutubeChannel(string channelId)
        {
            var request = this.Youtube.Channels.List("snippet");
            request.Id = channelId;
            var response = await request.ExecuteAsync();
            var channel = response.Items.First();

            return new YoutubeChannel(channel.Id,
                channel.Snippet.Title,
                channel.Snippet.Description);
        }
    }
}