using System.IO;
using Lacey.Medusa.Surfer.Services.LikesRock.Models.Auth;
using Newtonsoft.Json;

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
            return JsonConvert.DeserializeObject<UserSecrets>(File.ReadAllText(this.userSecretsFile));
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