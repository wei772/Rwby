using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Rwby.Global.ApiClient;
using Clients;

namespace Rwby.Global.Test
{
    [TestClass]
    public class TokenMangerTest
    {
        [TestMethod]
        public async Task CallServiceTestAsync()
        {
            Console.Title = "Console Client Credentials Flow";

            var manager = new TokenManger();
            var response = await manager.RequestTokenAsync();
            response.Show();

            await manager.CallServiceAsync(response.AccessToken);
        }

    }
}
