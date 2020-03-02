using Microsoft.AspNetCore.Identity;
using restapp.Data;
using restapp.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.Data
{
    public class SecuritySeeder
    {
        private readonly SecurityDbContext _securityContext;
        private readonly UserManager<RestAppUser> _userManager;

        public SecuritySeeder(SecurityDbContext securityContext, UserManager<RestAppUser> userManager)
        {
            _securityContext = securityContext;
            _userManager = userManager;
        }

        public async Task seed()
        {
            await _securityContext.Database.EnsureCreatedAsync();

            var adminUser = await _userManager.FindByEmailAsync("admin@evotech.com.mx");

            if (adminUser == null)
            {
                adminUser = new RestAppUser()
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    DataBaseName = "admin_restapp",
                    ClientName = "Admin",

                    UserName = "admin@evotech.com.mx",
                    Email = "admin@evotech.com.mx"
                };

                var result = await _userManager.CreateAsync(adminUser, "Passw0rd!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default admin user");
                }
            }
        }
    }
}
