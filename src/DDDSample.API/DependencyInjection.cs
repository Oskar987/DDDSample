namespace DDDSample.API
{
    using DDDSample.API.Middlewares;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
	{
		public static IServiceCollection AddPresentation(this IServiceCollection services)
		{
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<GloblalExceptionHandlingMiddleware>();
            return services;
		}
	}
}

