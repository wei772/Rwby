using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Clients;

namespace Rwby.Global.ApiClient
{
    public class TokenManger
    {

        public async Task<TokenResponse> RequestTokenAsync()
        {
            var disco = await DiscoveryClient.GetAsync(Constants.Authority);
            if (disco.IsError) throw new Exception(disco.Error);

            var client = new TokenClient(
                disco.TokenEndpoint,
                "client",
                "secret");

            var token = await client.RequestClientCredentialsAsync("GetUsers");
            return token;
        }

        public async Task CallServiceAsync(string token)
        {
            var baseAddress = Constants.SampleApi;

            var client = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };

            client.SetBearerToken(token);
            var response = await client.GetStringAsync("user/getusers");

            "\n\nService claims:".ConsoleGreen();
            Console.WriteLine(JArray.Parse(response));
        }
    }
}
