using System.IO;

namespace Lacey.Alexa.Common.Shodan.Providers.Concrete
{
    public sealed class ShodanAuthProvider : IShodanAuthProvider
    {
        private readonly string _secretsFile;

        public ShodanAuthProvider(string secretsFile)
        {
            _secretsFile = secretsFile;
        }

        public (string Username, string Password) GetCredentials()
        {
            var lines = File.ReadAllLines(_secretsFile);
            return (lines[0], lines[1]);
        }
    }
}