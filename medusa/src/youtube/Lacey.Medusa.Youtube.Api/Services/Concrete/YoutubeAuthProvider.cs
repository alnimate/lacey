using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Lacey.Medusa.Common.Auth.OAuth2.Base.OAuth2;
using Lacey.Medusa.Youtube.Api.Base;

namespace Lacey.Medusa.Youtube.Api.Services.Concrete
{
    public sealed class YoutubeAuthProvider : IYoutubeAuthProvider
    {
        private readonly string clientSecretsFilePath;

        private readonly string userName;

        public YoutubeAuthProvider(
            string clientSecretsFilePath, 
            string userName)
        {
            this.clientSecretsFilePath = clientSecretsFilePath;
            this.userName = userName;
        }

        public async Task<UserCredential> GetUserCredentials()
        {
            UserCredential credential;
            using (var stream = new FileStream(this.clientSecretsFilePath, FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[]
                    {
                        YouTubeService.Scope.YoutubeForceSsl,
                        YouTubeService.Scope.Youtubepartner,
                        YouTubeService.Scope.Youtube,
                        YouTubeService.Scope.YoutubeUpload
                    },
                    this.userName,
                    CancellationToken.None
                );
            }

            return credential;
        }
    }
}