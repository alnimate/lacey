using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lacey.Medusa.Common.Auth.Database
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext(DbContextOptions options)
            : base(options)
        {            
        }

        public AuthDbContext(string connectionString)
            : base(new DbContextOptionsBuilder()
                .UseSqlServer(connectionString, opt => opt.UseRowNumberForPaging()).Options)
        {
        }
    }
}