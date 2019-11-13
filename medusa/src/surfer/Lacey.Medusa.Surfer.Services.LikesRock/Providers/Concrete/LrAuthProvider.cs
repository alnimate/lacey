using System;
using System.IO;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;

namespace Lacey.Medusa.Surfer.Services.LikesRock.Providers.Concrete
{
    public sealed class LrAuthProvider : ILrAuthProvider
    {
        private readonly string userSecretsFile;

        private readonly string commonSecretsFile;

        public LrAuthProvider(
            string userSecretsFile, 
            string commonSecretsFile)
        {
            this.userSecretsFile = userSecretsFile;
            this.commonSecretsFile = commonSecretsFile;
        }

        public UserSecrets GetUserSecrets()
        {
            var lines = File.ReadAllLines(this.userSecretsFile);

            return new UserSecrets
            {
                Username = lines[0],
                Password = lines[1],
                YtSessionId = lines[2].Split(new [] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1],
                InSessionId = lines[3].Split(new [] { "=" }, StringSplitOptions.RemoveEmptyEntries)[1]
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