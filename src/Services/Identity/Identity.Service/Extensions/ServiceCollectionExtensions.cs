using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Rwby.Identity.Core;

namespace Rwby.Identity.Service
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddGlobalRepository(this IServiceCollection services)
        {
           
            return services;
        }


        public static IServiceCollection AddGlobalService(this IServiceCollection services)
        {
            return services;
        }



    }
}
