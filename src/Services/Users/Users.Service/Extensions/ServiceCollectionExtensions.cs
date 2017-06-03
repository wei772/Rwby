
using Microsoft.Extensions.DependencyInjection;
using Rwby.Users.Core;

namespace Rwby.Users.Service
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddUsersRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }


        public static IServiceCollection AddUsersService(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            return services;
        }



    }
}
