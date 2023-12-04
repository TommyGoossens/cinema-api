using Microsoft.Extensions.DependencyInjection;

namespace Cinema.Application.Core.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void RegisterMediatorHandlers(this IServiceCollection services)
		{
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        }
	}
}

