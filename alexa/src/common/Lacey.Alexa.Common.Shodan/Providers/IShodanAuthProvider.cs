namespace Lacey.Alexa.Common.Shodan.Providers
{
    public interface IShodanAuthProvider
    {
        (string Username, string Password) GetCredentials();
    }
}