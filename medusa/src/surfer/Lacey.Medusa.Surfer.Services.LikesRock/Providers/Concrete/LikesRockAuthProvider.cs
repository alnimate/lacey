using System.IO;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Providers.Concrete
{
    public sealed class LikesRockAuthProvider : ILikesRockAuthProvider
    {
        private readonly string userSecretsFile;

        private readonly string commonSecretsFile;

        public LikesRockAuthProvider(
            string userSecretsFile, 
            string commonSecretsFile)
        {
            this.userSecretsFile = userSecretsFile;
            this.commonSecretsFile = commonSecretsFile;
        }

        public Credentials GetCredentials()
        {
            var lines = File.ReadAllLines(this.userSecretsFile);

            return new Credentials
            {
                Username = lines[0],
                Password = lines[1]
            };
        }

        public CommonSecrets GetCommonSecrets()
        {
            var lines = File.ReadAllLines(this.commonSecretsFile);

            return new CommonSecrets
            {
                HashKey = lines[0]
            };
        }
    }
}