using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Rwby.Identity.Core;

namespace Rwby.Identity.Core
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddGlobalMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GlobalMapProfile());
            });
            services.AddSingleton(sp => config.CreateMapper());

            return services;
        }

    }
}
