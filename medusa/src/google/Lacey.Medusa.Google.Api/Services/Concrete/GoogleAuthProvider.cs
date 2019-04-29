using System.IO;

namespace Lacey.Medusa.Google.Api.Services.Concrete
{
    public sealed class GoogleAuthProvider : IGoogleAuthProvider
    {
        private readonly string[] lines;

        public GoogleAuthProvider(string clientSecretsFilePath)
        {
            this.lines = File.ReadAllLines(clientSecretsFilePath);
        }

        public string GetApiKey()
        {
            return lines[0];
        }

        public string GetCx()
        {
            return lines[1];
        }
    }
}