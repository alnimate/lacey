using System.IO;

namespace Lacey.Medusa.Facebook.Api.Services.Concrete
{
    public sealed class FacebookAuthProvider : IFacebookAuthProvider
    {
        private readonly string clientSecretsFilePath;

        public FacebookAuthProvider(string clientSecretsFilePath)
        {
            this.clientSecretsFilePath = clientSecretsFilePath;
        }

        public string GetAccessToken()
        {
            var lines = File.ReadAllLines(this.clientSecretsFilePath);
            return lines[0];
        }
    }
}