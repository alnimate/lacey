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

        public string GetApiKey()
        {
            var lines = File.ReadAllLines(_secretsFile);
            return lines[0];
        }
    }
}