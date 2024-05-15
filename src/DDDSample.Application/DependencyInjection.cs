namespace DDDSample.Application
{
    using DDDSample.Application.Common.Behaviors;
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;
	using MediatR;

    public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(config =>
			{
				config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
			});

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

			services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

			return services;
		}
	}
}

