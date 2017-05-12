using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using Rwby.Global.Core;
using IdentityServer4;
using NLog.Extensions.Logging;
using NLog.Web;
using Microsoft.AspNetCore.Http;

namespace Rwby.Global.Web
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

            env.ConfigureNLog("nlog.config");
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();


            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddTestUsers(IdentityServerConfig.GetUsers())
            ;

            //call this in case you need aspnet-user-authtype/aspnet-user-identity
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            // loggerFactory.AddDebug();

            //add NLog to ASP.NET Core
            loggerFactory.AddNLog();

            //add NLog.Web
            app.AddNLogWeb();

            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "Cookies"
            });


            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
            {
                AuthenticationScheme = "oidc",
                //SignInScheme = "Cookies",
                SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme,
                Authority = "http://localhost:50274",
                RequireHttpsMetadata = false,

                ClientId = "mvc",
                ClientSecret = "secret",

                ResponseType = "code id_token",
                Scope = { "UserApi", "offline_access" },

                SaveTokens = true
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
