namespace Lacey.Alexa.Common.Metasploit.Providers
{
    public interface IMetasploitAuthProvider
    {
        (string Username, string Password) GetCredentials();
    }
}