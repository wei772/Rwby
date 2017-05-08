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

            var manager = new TokenManger();
            var response = await manager.RequestTokenAsync();
            response.Show();

            var result = await manager.CallServiceAsync(response.AccessToken, "user/getusers");

            Console.WriteLine("result");

        }


        [TestMethod]
        public async Task CallServiceWithPasswordTestAsync()
        {

            var manager = new TokenManger();
            var response = await manager.RequestTokenWithPasswordAsync();
            response.Show();

            var result = manager.CallServiceAsync(response.AccessToken, "user/getuser?userId=2f63448e-41a5-4757-a0a7-03d1ecf30696");

            Console.WriteLine("result");
        }

    }
}
