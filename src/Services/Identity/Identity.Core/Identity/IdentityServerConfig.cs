using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Rwby.Identity.Core
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("UserApi", "User API"),

                new ApiResource
            {
                Name = "api",
                DisplayName = "API",
                Scopes = new[]
                {
                    new Scope("readAccess", "Access read operations"),
                    new Scope("writeAccess", "Access write operations")
                }
            }
        };
        }


        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "UserApi" }
                },

                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "UserApi" }
                },

                
                // other clients omitted...

                // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                     ClientSecrets =
                        {
                         new Secret("secret".Sha256())
                        },
                    // where to redirect to after login
                    RedirectUris = { "http://localhost:40111/signin-oidc" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "http://localhost:40111/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "UserApi"
                    },
                    AllowOfflineAccess = true
                },


                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:40115/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:40115/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:40115" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "UserApi"
                    }
                },


                new Client
                {
                    AllowAccessTokensViaBrowser = true,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new[] { "UserApi", "readAccess", "writeAccess" },
                    ClientId = "swagger-ui",
                    ClientName = "Swagger UI",
                    ClientSecrets = new[] { new Secret("swagger-ui-secret".Sha256()) },
                    RedirectUris = new[] { "http://localhost:40707/swagger/o2c.html" }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
             {
                 new TestUser
                 {
                     SubjectId = "1",
                     Username = "alice",
                     Password = "password",

                    Claims = new []
                    {
                        new Claim("name", "Alice"),
                        new Claim("website", "https://alice.com")
                    }
                 },

                 new TestUser
                 {
                     SubjectId = "2",
                     Username = "bob",
                     Password = "password",
                    Claims = new []
                    {
                        new Claim("name", "Bob"),
                        new Claim("website", "https://bob.com")
                    }
                 }
             };
        }


        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
    }
}
