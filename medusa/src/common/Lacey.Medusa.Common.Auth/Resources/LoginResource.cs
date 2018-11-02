using System.ComponentModel.DataAnnotations;

namespace Lacey.Medusa.Common.Auth.Resources
{
    public sealed class LoginResource
    {
        public LoginResource()
        {            
        }

        public LoginResource(
            string userName,
            string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}