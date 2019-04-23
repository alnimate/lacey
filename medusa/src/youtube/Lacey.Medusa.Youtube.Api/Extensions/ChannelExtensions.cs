using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Youtube.Api.Extensions
{
    public static class ChannelExtensions
    {
        public static string GetBannerUrl(this Channel channel)
        {
            return channel.BrandingSettings.Image.BannerTvHighImageUrl;
        }

        public static void SetBannerUrl(this Channel channel, string bannerUrl)
        {
            channel.BrandingSettings.Image.BannerTvHighImageUrl = bannerUrl;
        }
    }
}