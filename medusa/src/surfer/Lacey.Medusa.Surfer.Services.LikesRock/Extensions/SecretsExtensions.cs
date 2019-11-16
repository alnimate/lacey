using System.Linq;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Extensions
{
    internal static class SecretsExtensions
    {
        internal static string GetSocialId(this UserSecrets us, string name)
        {
            var social = us.Socials?.FirstOrDefault(s => s.Name == name);
            return social == null ? string.Empty : social.Id;
        }
    }
}