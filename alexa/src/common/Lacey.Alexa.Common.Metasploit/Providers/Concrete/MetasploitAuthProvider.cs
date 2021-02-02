using System.IO;

namespace Lacey.Alexa.Common.Metasploit.Providers.Concrete
{
    public sealed class MetasploitAuthProvider : IMetasploitAuthProvider
    {
        private readonly string _secretsFile;

        public MetasploitAuthProvider(string secretsFile)
        {
            this._secretsFile = secretsFile;    
        }

        public (string Username, string Password) GetCredentials()
        {
            var lines = File.ReadAllLines(_secretsFile);
            return (lines[0], lines[1]);
        }
    }
}