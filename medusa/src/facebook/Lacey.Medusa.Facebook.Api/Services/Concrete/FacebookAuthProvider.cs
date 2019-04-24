namespace Lacey.Medusa.Facebook.Api.Services.Concrete
{
    public sealed class FacebookAuthProvider : IFacebookAuthProvider
    {
        private readonly string clientSecretsFilePath;

        public FacebookAuthProvider(string clientSecretsFilePath)
        {
            this.clientSecretsFilePath = clientSecretsFilePath;
        }
    }
}