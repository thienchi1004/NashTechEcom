﻿using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Ecom.Backend.IdentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
             new ApiScope[]
             {
                  new ApiScope("assignmentecommerce.api", "Assignment Ecommerce API")
             };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // machine to machine client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = { "assignmentecommerce.api" }
                },

                // interactive ASP.NET Core MVC client
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { Startup.ClientUrls["mvc"]+ "/signin-oidc" },

                    PostLogoutRedirectUris = { Startup.ClientUrls["mvc"]+ "/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "assignmentecommerce.api"
                    }
                },

                new Client
                {
                    ClientId = "swagger",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,

                    RequireConsent = false,
                    RequirePkce = true,

                    RedirectUris =           { Startup.ClientUrls["backend"] + "/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { Startup.ClientUrls["backend"] + "/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins =     { Startup.ClientUrls["backend"] },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "assignmentecommerce.api"
                    }
                },
            };
    }
}
