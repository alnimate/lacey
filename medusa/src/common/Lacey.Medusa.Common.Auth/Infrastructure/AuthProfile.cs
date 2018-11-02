using AutoMapper;
using Lacey.Medusa.Common.Auth.Models;
using Lacey.Medusa.Common.Auth.Resources;
using Lacey.Medusa.Common.Auth.Utils;
using Microsoft.AspNetCore.Identity;

namespace Lacey.Medusa.Common.Auth.Infrastructure
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            this.CreateMap<RegisterResource, Register>()
                .ConstructUsing(
                    r => new Register(
                        r.UserName,
                        r.Email,
                        r.Password));

            this.CreateMap<LoginResource, Login>()
                .ConstructUsing(
                    r => new Login(
                        r.UserName,
                        r.Password));

            this.CreateMap<RegisterResult, RegisterResultResource>();

            this.CreateMap<LoginResult, LoginResultResource>();

            this.CreateMap<LoggedInUser, LoggedInUserResource>();

            this.CreateMap<IdentityUser, LoggedInUser>()
                .ConstructUsing(
                    i => new LoggedInUser(
                        i.UserName,
                        i.Email,
                        CryptoUtils.CreateToken(i)));
        }
    }
}