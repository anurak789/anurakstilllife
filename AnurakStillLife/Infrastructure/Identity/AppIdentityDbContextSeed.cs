using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Anu",
                    Email = "anu@stilllife.com",
                    UserName = "anu@stilllife.com",
                    Address = new Address
                    {
                        FirstName = "Om",
                        LastName = "Omity",
                        Street = "111 main street",
                        City = "Jacksonville",
                        StateProvince = "Florida",
                        ZipCode = "32211"
                    }
                };

                await userManager.CreateAsync(user, "Thk$$Y0cZ");
            }
        }
    }
}
