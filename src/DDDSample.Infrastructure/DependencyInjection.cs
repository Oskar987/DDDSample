using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using DDDSample.Application.Data;
using DDDSample.Domain.Customers;
using DDDSample.Domain.Primitives;
using DDDSample.Infrastructure.Models;
using DDDSample.Infrastructure.Persistence;
using DDDSample.Infrastructure.Persistence.Repositories;
using DDDSample.Infrastructure.Auth.Abstractions;
using DDDSample.Infrastructure.Auth.Implementations;

namespace DDDSample.Infrastructure
{
    public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("ApplicationConnection")));

            services.AddScoped<IApplicationDbContext>(sp =>
			sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddIdentity(configuration);

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<InfrastructureAssemblyReference>();
            });

            services.AddScoped<IJWTGenerator, JWTGenerator>();

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("IdentityConnection")));

            services.AddScoped<IApplicationIdentityDbContext>(sp =>
            sp.GetRequiredService<ApplicationIdentityDbContext>());

            var builder = services.AddIdentityCore<ApplicationUser>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            identityBuilder.AddEntityFrameworkStores<ApplicationIdentityDbContext>();
            identityBuilder.AddSignInManager<SignInManager<ApplicationUser>>();

            return services;
        }
	}
}

