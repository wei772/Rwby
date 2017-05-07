using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rwby.Global.Core;
using Rwby.Global.Service;

namespace Rwby.Global.Api
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
            services.AddGlobalMapper()
                .AddGlobalRepository()
                .AddGlobalService()
                .AddMvc();

            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                ;


            ConfigureDbContext(services);
        }



        public void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<GlobalContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserConnection")));

            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<GlobalContext>()
               .AddDefaultTokenProviders();

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:50707",
                RequireHttpsMetadata = false,
                ApiName = "GetUsers"
            });


            if (env.IsDevelopment())
            {
                // 这个很有用
                app.UseDeveloperExceptionPage();
            }


            app.UseIdentityServer();


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
