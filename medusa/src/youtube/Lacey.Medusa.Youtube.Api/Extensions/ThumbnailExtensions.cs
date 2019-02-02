using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Youtube.Api.Extensions
{
    public static class ThumbnailExtensions
    {
        public static string GetMaxResUrl(
            this ThumbnailDetails thumbnails)
        {
            string url = string.Empty;
            if (thumbnails.Maxres != null)
            {
                url = thumbnails.Maxres.Url;
            }
            else if (thumbnails.High != null)
            {
                url = thumbnails.High.Url;
            }
            else if (thumbnails.Medium != null)
            {
                url = thumbnails.Medium.Url;
            }
            else if (thumbnails.Standard != null)
            {
                url = thumbnails.Standard.Url;
            }
            else if (thumbnails.Default__ != null)
            {
                url = thumbnails.Default__.Url;
            }

            return url;
        }
    }
}