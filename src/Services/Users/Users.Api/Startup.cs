using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Rwby.AspNetCore.Authorization;
using Rwby.AspNetCore.Identity;
using Rwby.Http;
using Rwby.Users.Core;
using Rwby.Users.Service;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rwby.Users.Api
{

    // SecurityRequirementsOperationFilter.cs
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        private readonly IOptions<AuthorizationOptions> authorizationOptions;

        public SecurityRequirementsOperationFilter(IOptions<AuthorizationOptions> authorizationOptions)
        {
            this.authorizationOptions = authorizationOptions;
        }

        public void Apply(Operation operation, OperationFilterContext context)
        {

        }
    }


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

            //services.AddSwaggerGen();
            var pathToDoc = "Users.Api.xml";

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                 new Info
                 {
                     Title = "user API",
                     Version = "v1",
                     Description = "user api",
                     TermsOfService = "None"
                 }
              );


                // Define the OAuth2.0 scheme that's in use (i.e. Implicit Flow)
                c.AddSecurityDefinition("oauth2", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "implicit",
                    AuthorizationUrl = "http://localhost:40274/connect/authorize",
                    Scopes = new Dictionary<string, string>
                    {
                        { "UserApi", "user api" },
                    }
                });
                // Assign scope requirements to operations based on AuthorizeAttribute
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Users.Api.xml");
                c.IncludeXmlComments(xmlPath);

            });

            ConfigureDbContext(services);

            services.AddSingleton<IResilientHttpClientFactory, ResilientHttpClientFactory>();
            services.AddSingleton<IHttpClient, ResilientHttpClient>(sp => sp.GetService<IResilientHttpClientFactory>().CreateResilientHttpClient());

            //call this in case you need aspnet-user-authtype/aspnet-user-identity
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserPermissonProvider, RemoteUserPermissonProvider>(
                (provider) =>
                {
                    return new RemoteUserPermissonProvider(new RemoteUserPermissonOptions() { ApiUrl = "http://localhost:40274/Permission/GetUserPermission" }
                        , provider.GetService<IHttpContextAccessor>()
                        , provider.GetService<IHttpClient>()
                    );
                });
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

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
                    //options.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    options.MapRoute("default", "api/{controller}/{action}/{id?}");
                }
            );


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) => swagger.Host = httpReq.Host.Value);
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User API V1");

                c.ConfigureOAuth2("swagger-ui", "swagger-ui-secret", "swagger-ui-realm", "Swagger UI");
            });

            app.Run(async context =>
           {
               await context.Response.WriteAsync("can't find api");
           });
        }
    }
}
