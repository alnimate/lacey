using System.Collections.Generic;
using System.Linq;
using InstagramApiSharp.Classes.Models;

namespace Lacey.Medusa.Instagram.Services.Extensions
{
    internal static class MediaExtensions
    {
        public static InstaUserTagUpload[] AsUpload(
            this IEnumerable<InstaUserTag> userTags,
            string userName)
        {
            var tags = new InstaUserTagUpload[0];
            if (userTags != null)
            {
                tags = userTags.Select(t =>
                {
                    var tag = new InstaUserTagUpload();

                    if (t.User != null &&
                        !string.IsNullOrEmpty(t.User.UserName))
                    {
                        tag.Username = userName;
                    }

                    if (t.Position != null)
                    {
                        tag.X = t.Position.X;
                        tag.Y = t.Position.Y;
                    }

                    return tag;
                }).ToArray();
            }

            return tags;
        }
    }
}