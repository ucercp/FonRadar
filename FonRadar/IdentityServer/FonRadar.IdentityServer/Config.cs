using IdentityServer4.Models;
using IdentityServer4;
using System.Collections.Generic;
namespace FonRadar.IdentityServer;
public static class Config
{
   
    public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
    {
        new ApiResource("ResourceInvoice"){ Scopes = { "InvoiceFullPermission" }},
        new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
    };

  
    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
    {
        new ApiScope("InvoiceFullPermission", "Fatura için tam yetki"),
        new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
    };

   
    public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
    {
        new IdentityResources.OpenId(), 
        new IdentityResources.Profile() 
    };

    public static IEnumerable<Client> Clients => new Client[]
    {
        new Client
        {
            ClientId = "supplier_client",
            ClientName = "Tedarikçi Client",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("FonRadarsecret".Sha256()) },
            AllowedScopes = { "InvoiceFullPermission", IdentityServerConstants.LocalApi.ScopeName }
        },
        new Client
        {
            ClientId = "financial_client",
            ClientName = "Finansal Kurum Client",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("FonRadarsecret".Sha256()) },
            AllowedScopes = { "InvoiceFullPermission", IdentityServerConstants.LocalApi.ScopeName }
        },
          new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("interactive_secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "http://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "http://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "http://localhost:44300/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "supplier_scope", "financial_scope", IdentityServerConstants.LocalApi.ScopeName }
                }
			
    };
}
