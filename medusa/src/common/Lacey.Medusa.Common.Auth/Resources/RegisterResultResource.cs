using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Lacey.Medusa.Common.Auth.Resources
{
    public sealed class RegisterResultResource
    {
        public RegisterResultResource()
        {            
        }

        public RegisterResultResource(
            LoggedInUserResource user,
            IEnumerable<IdentityError> errors)
        {
            this.User = user;
            this.Errors = errors;
        }

        public LoggedInUserResource User { get; set; }

        public IEnumerable<IdentityError> Errors { get; set; }
    }
}