// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Structure.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
                new ApiScope("structureapi")
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("structureapi",
                    "ABP like structure API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "scope1" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    
                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2" }
                },

                //Blazor WASM :Sturcture.Blazor
                new Client
                {
                    ClientId = "structure",
                    ClientName="ABP like structure",

                    //secrets can't be safely stored in js
                    //ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    RequireClientSecret=false,

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce=true,
                    
                    //refer to the Blazor app
                    RedirectUris = { "https://localhost:44354/authentication/login-callback" },
                    //FrontChannelLogoutUri = "https://localhost:44354/signout-oidc",
                    //make sure to write logout-callback NOT signout-callback or else error when logging out
                    PostLogoutRedirectUris = { "https://localhost:44354/authentication/logout-callback" },

                    //AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "email", "structureapi" },
                    //cors from the client, because the IDS is hosted on another origin as the client
                    AllowedCorsOrigins={ "https://localhost:44354" }

                },
            };
    }
}