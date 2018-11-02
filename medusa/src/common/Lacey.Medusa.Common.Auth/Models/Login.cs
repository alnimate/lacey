using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.Auth.Models
{
    public sealed class Login
    {
        public Login(
            string userName,
            string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        [Required]
        public string UserName { get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; }
    }
}