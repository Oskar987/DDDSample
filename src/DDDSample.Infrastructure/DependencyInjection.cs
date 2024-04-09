namespace DDDSample.Infrastructure
{
    using DDDSample.Application.Data;
    using DDDSample.Domain.Customers;
    using DDDSample.Domain.Primitives;
    using DDDSample.Infrastructure.Persistence;
    using DDDSample.Infrastructure.Persistence.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Postgres")));

            services.AddScoped<IApplicationDbContext>(sp =>
			sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
	}
}

