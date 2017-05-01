using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using Rwby.Global.Service;
using Microsoft.EntityFrameworkCore;
using Rwby.Global.Core;
using AutoMapper;

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
            ConfigureMapper(services);
            ConfigureDbContext(services);
            ConfigureRepository(services);
            ConfigureBaseService(services);

            services.AddMvc();


            //IServiceProvider serviceProvider = services.BuildServiceProvider();
        }

        public void ConfigureMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMapProfile());
            });
            services.AddSingleton(sp => config.CreateMapper());
        }

        public void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<UserContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UserConnection")));
        }

        public void ConfigureRepository(IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
        }

        public void ConfigureBaseService(IServiceCollection services)
        {
            services.AddScoped<UserService>();
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
