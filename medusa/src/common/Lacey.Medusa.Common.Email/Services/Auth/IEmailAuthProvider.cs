namespace Lacey.Medusa.Common.Email.Services.Auth
{
    public interface IEmailAuthProvider
    {
        string Username { get; }

        string Password { get; }
    }
}