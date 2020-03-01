using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using restapp.Domain.Security;

namespace restapp.Data
{
    public class SecurityDbContext : IdentityDbContext<RestAppUser>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {

        }
    }
}
