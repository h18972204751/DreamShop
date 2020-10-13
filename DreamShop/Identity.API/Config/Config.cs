using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Config
{
    public class Config
    {
        //定义要保护的资源（webapi）
        public static IEnumerable<ApiScope> GetApiResources()
        {
            return new List<ApiScope>
             {
                 new ApiScope("api", "My API")
             };
        }
        //定义可以访问该API的客户端
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
             {
                new Client
                {
                    ClientId = "client",
                    ClientName = "Client Name",
                    AllowOfflineAccess = true,  //是否可以离线访问，refresh
                    AllowedGrantTypes = GrantTypes.ClientCredentials,   //客户端模式
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },
                    AllowedScopes = { "api", IdentityServerConstants.StandardScopes.OfflineAccess }
                },
                new Client
                {
                    ClientId = "password",
                    ClientName = "Password Name",
                    AllowOfflineAccess = true,  //是否可以离线访问，refresh
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,   //密码模式
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A1".Sha256()) },
                    RefreshTokenUsage=TokenUsage.ReUse,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowedScopes=new List<string>
                    {
                        "api",
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    }
                },
             };
        }
        public static List<TestUser> GeTestUsers()
        {
            return new List<TestUser>
             {
                 new TestUser
                 {
                     SubjectId = "1",
                     Username = "alice",
                     Password = "password"
                 },
                 new TestUser
                 {
                     SubjectId = "2",
                     Username = "bob",
                     Password = "password"
                 }
             };
        }
        //openid  connect
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
             {
                 new IdentityResources.OpenId(),
                 new IdentityResources.Profile(),
                 new IdentityResources.Email()
             };
        }
    }

}
