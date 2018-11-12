using System.IO;
using System.Linq;

namespace Lacey.Medusa.Common.Email.Services.Auth.Concrete
{
    public sealed class SimpleEmailAuthProvider : IEmailAuthProvider
    {
        public SimpleEmailAuthProvider(
            string userName,
            string secretFilePath)
        {
            this.Username = userName;
            this.Password = File.ReadLines(secretFilePath).First();
        }

        public string Username { get; }

        public string Password { get; }
    }
}