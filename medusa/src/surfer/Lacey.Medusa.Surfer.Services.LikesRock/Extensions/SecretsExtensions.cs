using System.Linq;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Extensions
{
    internal static class SecretsExtensions
    {
        internal static Social GetUsersSocial(this UserSecrets us, string name)
        {
            return us.Socials?.FirstOrDefault(s => s.Name == name);
        }
    }
}