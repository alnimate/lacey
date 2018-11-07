using System.IO;
using System.Linq;

namespace Lacey.Medusa.Youtube.Api.Services.Auth.Concrete
{
    public sealed class SimpleYoutubeAuthProvider : IYoutubeAuthProvider
    {
        private readonly string apiKeyFile;

        public SimpleYoutubeAuthProvider(string apiKeyFile)
        {
            this.apiKeyFile = apiKeyFile;
        }

        public string GetApiKey()
        {
            return File.ReadLines(this.apiKeyFile).First();
        }
    }
}