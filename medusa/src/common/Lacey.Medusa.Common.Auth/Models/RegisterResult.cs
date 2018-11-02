using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Lacey.Medusa.Common.Auth.Models
{
    public sealed class RegisterResult
    {
        public RegisterResult(
            LoggedInUser user,
            IEnumerable<IdentityError> errors)
        {
            this.User = user;
            this.Errors = errors;
        }

        public LoggedInUser User { get; }

        public IEnumerable<IdentityError> Errors { get; }
    }
}