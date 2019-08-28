using System.IO;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Providers.Concrete
{
    public sealed class LikesRockAuthProvider : ILikesRockAuthProvider
    {
        private readonly string secretsFilePath;

        public LikesRockAuthProvider(string secretsFilePath)
        {
            this.secretsFilePath = secretsFilePath;
        }

        public Credentials GetCredentials()
        {
            var lines = File.ReadAllLines(this.secretsFilePath);

            return new Credentials
            {
                Username = lines[0],
                Password = lines[1]
            };
        }
    }
}