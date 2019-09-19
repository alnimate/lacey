using System.Collections.Generic;
using System.IO;
using System.Linq;
using InstagramApiSharp.Classes.Models;

namespace Lacey.Medusa.Instagram.Api.Extensions
{
    public static class MediaExtensions
    {
        public static InstaImageUpload AsUpload(
            this InstaImage image,
            InstaMedia media,
            string uri)
        {
            var imageUpload = new InstaImageUpload(uri, image.Width, image.Height);
            var tagsUpload = new List<InstaUserTagUpload>();
            if (media.UserTags != null)
            {
                foreach (var tag in media.UserTags)
                {
                    var tagUpload = new InstaUserTagUpload();
                    if (tag.User != null)
                    {
                        tagUpload.Username = tag.User.UserName;
                    }

                    if (tag.Position != null)
                    {
                        tagUpload.X = tag.Position.X;
                        tagUpload.Y = tag.Position.Y;
                    }

                    tagsUpload.Add(tagUpload);
                }
            }
            imageUpload.UserTags.AddRange(tagsUpload);
            return imageUpload;
        }

        public static InstaVideoUpload AsUpload(
            this InstaVideo video,
            string uri)
        {
            video.VideoBytes = File.ReadAllBytes(uri);
            var thumbnail = new InstaImage();
            return new InstaVideoUpload(video, thumbnail);
        }

        public static IEnumerable<InstaImage> GetImages(
            this InstaMedia media)
        {
            if (media.Images == null)
            {
                return new InstaImage[0];
            }

            return media.Images.Where(i => i.Width == media.Images.Max(m => m.Width));
        }

        public static InstaImage[] GetAlbumImages(this InstaMedia media)
        {
            var list = new List<InstaImage>();
            if (media.Carousel != null)
            {
                foreach (var carousel in media.Carousel)
                {
                    if (carousel.Images != null)
                    {
                        foreach (var image in carousel.Images?.Where(i => i.Width == carousel.Width))
                        {
                            list.Add(image);
                        }
                    }
                }
            }

            return list.ToArray();
        }

        public static IEnumerable<InstaVideo> GetOriginalVideos(
            this InstaMedia media)
        {
            if (media.Videos == null)
            {
                return new InstaVideo[0];
            }

            return media.Videos.Where(i => i.Width == media.Width);
        }
    }
}