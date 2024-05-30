using DDDSample.Infrastructure.Models;
using DDDSample.Infrastructure.Persistence;
using DDDSample.Infrastructure.Persistence.Seeds.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DDDSample.API.Extensions
{
    public static class MigrationExtensions
	{
		public async static Task ApplyMigrations(this WebApplication app)
		{
            using var scope = app.Services.CreateScope();

            try
            {
                var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                await applicationDbContext.Database.MigrateAsync();

                var identityDbContext = scope.ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                await IdentitySeed.SeedDataAsync(identityDbContext, userManager);
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occured during seed migrations");
            }
			
        }
	}
}

