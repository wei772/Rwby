using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using IdentityConstants;

namespace Rwby.Identity.ApiClient
{
    public class TokenManger
    {

        public async Task<TokenResponse> RequestTokenAsync()
        {
            var disco = await DiscoveryClient.GetAsync(Constants.Authority);
            if (disco.IsError)
            {
                throw new Exception(disco.Error);
            }

            var client = new TokenClient(
                disco.TokenEndpoint,
                "client",
                "secret");

            var token = await client.RequestClientCredentialsAsync("UserApi");
            return token;
        }


        public async Task<TokenResponse> RequestTokenWithPasswordAsync()
        {

            var disco = await DiscoveryClient.GetAsync(Constants.Authority);
            if (disco.IsError) throw new Exception(disco.Error);

            var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "UserApi");

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            return tokenResponse;

        }


        public async Task<string> CallServiceAsync(string token, string api)
        {
            var baseAddress = Constants.SampleApi;

            var client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };

            client.SetBearerToken(token);
            var response = await client.GetStringAsync(api);
            return response;

        }
    }
}
