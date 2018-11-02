using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.Auth.Models
{
    public sealed class Register
    {
        public Register(
            string userName,
            string email, 
            string password)
        {
            this.UserName = userName;
            this.Email = email;
            this.Password = password;
        }

        [Required]
        public string UserName { get; }

        [Required]
        [EmailAddress]
        public string Email { get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; }
    }
}