using System.IO;

namespace Lacey.Alexa.Common.Metasploit.Providers.Concrete
{
    public sealed class MetasploitAuthProvider : IMetasploitAuthProvider
    {
        private readonly string _userSecretsFile;

        public MetasploitAuthProvider(string userSecretsFile)
        {
            this._userSecretsFile = userSecretsFile;    
        }

        public (string Username, string Password) GetUserSecrets()
        {
            var lines = File.ReadAllLines(_userSecretsFile);
            return (lines[0], lines[1]);
        }
    }
}