using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddInfratructureService(this IServiceCollection services)
        {
            return services;
        }

    }
}
