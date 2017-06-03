using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Rwby.Users.Core;

namespace Rwby.Users.Core
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddUsersMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsersMapProfile());
            });
            services.AddSingleton(sp => config.CreateMapper());

            return services;
        }

    }
}
