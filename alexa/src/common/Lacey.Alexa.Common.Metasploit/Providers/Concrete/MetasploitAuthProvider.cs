using System.IO;
using Lacey.Alexa.Common.Metasploit.Models.Auth;

namespace Lacey.Alexa.Common.Metasploit.Providers.Concrete
{
    public sealed class MetasploitAuthProvider : IMetasploitAuthProvider
    {
        private readonly string _userSecretsFile;

        public MetasploitAuthProvider(string userSecretsFile)
        {
            this._userSecretsFile = userSecretsFile;
        }

        public UserSecrets GetUserSecrets()
        {
            var lines = File.ReadAllLines(_userSecretsFile);

            return new UserSecrets
            {
                Username = lines[0],
                Password = lines[1]
            };
        }
    }
}