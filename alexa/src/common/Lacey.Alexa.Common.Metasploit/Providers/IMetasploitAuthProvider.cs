using Lacey.Alexa.Common.Metasploit.Models.Auth;

namespace Lacey.Alexa.Common.Metasploit.Providers
{
    public interface IMetasploitAuthProvider
    {
        UserSecrets GetUserSecrets();
    }
}