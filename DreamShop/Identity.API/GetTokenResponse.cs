using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Identity.API
{
    public static class GetTokenResponse
    {
        public static async Task<string> GetTokenClient()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return null;
            }
            // GrantTypes.ResourceOwnerPassword.FirstOrDefault(),//Resource Owner Password模式
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
                Scope = "api"
            });
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return null;
            }
            return tokenResponse.AccessToken;
        }

        public static async Task<string> GetTokenPassword()
        {

            var httpClient = new HttpClient();
            var disco = httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "http://localhost:5000",
                Policy =
                {
                     RequireHttps=false
                }
            }).Result;
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }
            var tokenResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "password",
                ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A1",

                UserName = "alice",
                Password = "password",
                Scope = "api"
            });
            string token = tokenResponse.AccessToken;
            Console.Write(token);
            return token;
        }



    }
}
