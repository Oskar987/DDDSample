using System;
using DDDSample.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace DDDSample.Infrastructure.Persistence.Seeds.Identity
{
	public class IdentitySeed
	{
        public static async Task SeedDataAsync(ApplicationIdentityDbContext context, UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                        {
                            DisplayName = "PavelIvanov",
                            UserName = "PavelIvanov",
                            FirstName = "Pavel",
                            LastName= "Ivanov",
                            Email = "testuserfirst@test.com"
                        },

                    new ApplicationUser
                        {
                            DisplayName = "DmitryIvanov",
                            UserName = "DmitryIvanov",
                            FirstName = "Dmitry",
                            LastName= "Ivanov",
                            Email = "testusersecond@test.com"
                        }
                };

                foreach (var user in users)
                {
                        await userManager.CreateAsync(user, "qazwsX123!");
                }
            }
        }
    }
}

