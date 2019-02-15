using InstagramApiSharp.Classes.Models;
using Lacey.Medusa.Boost.Services.Const;

namespace Lacey.Medusa.Boost.Services.Extensions
{
    internal static class MediaExtensions
    {
        public static string GetInstagramUrl(
            this InstaMedia media)
        {
            if (media == null ||
                string.IsNullOrEmpty(media.Code))
            {
                return string.Empty;
            }

            return $"{InstagramConst.InstagramMediaUrl}{media.Code}";
        }
    }
}