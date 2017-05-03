using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Rwby.Global.Core;

namespace Rwby.Global.Service
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddGlobalRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }


        public static IServiceCollection AddGlobalService(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            return services;
        }



    }
}
