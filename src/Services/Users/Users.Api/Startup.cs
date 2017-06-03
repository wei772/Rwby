using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rwby.Users.Core;
using Rwby.Users.Service;

namespace Rwby.Users.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddUsersMapper()
                .AddUsersRepository()
                .AddUsersService()
                .AddMvc();



            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:40115")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });


            ConfigureDbContext(services);
        }



        public void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<UsersContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UsersConnection")));

      

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            if (env.IsDevelopment())
            {
                // 这个很有用
                app.UseDeveloperExceptionPage();
            }


            app.UseCors("default");

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:40274",
                RequireHttpsMetadata = false,
                AllowedScopes = { "UserApi" }
            });


            app.UseMvc
                (
                options =>
                {
                    options.MapRoute("apidefault", "api/{controller}/{action}/{id?}");
                }
            );

            app.Run(async context =>
           {
               await context.Response.WriteAsync("can't find api");
           });
        }
    }
}
