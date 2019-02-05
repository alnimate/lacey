using System.IO;
using InstagramApiSharp.Classes;

namespace Lacey.Medusa.Instagram.Api.Services.Concrete
{
    public sealed class InstagramAuthProvider : IInstagramAuthProvider
    {
        private readonly string clientSecretsFilePath;

        public InstagramAuthProvider(string clientSecretsFilePath)
        {
            this.clientSecretsFilePath = clientSecretsFilePath;
        }

        public UserSessionData GetUserSessionData()
        {
            var lines = File.ReadAllLines(this.clientSecretsFilePath);

            return new UserSessionData
            {
                UserName = lines[0],
                Password = lines[1]
            };
        }
    }
}