using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Rwby.Global.ApiClient;
using IdentityConstants;
using System.Text;

namespace Rwby.Global.Test
{
    [TestClass]
    public class TokenMangerTest
    {
        [TestInitialize]
        public void Init()
        {
            Console.WriteLine($"{Console.OutputEncoding}");

            Console.WriteLine("init:初始化");

            Console.OutputEncoding = Encoding.UTF8;
            // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);


            CheckEncoding();

            Console.WriteLine("init:初始化");
            CheckEncoding();

        }

        public void CheckEncoding()
        {
            try
            {
                Console.WriteLine(Encoding.GetEncoding(936));
            }

            catch (Exception ex)

            {
                Console.WriteLine(ex.Message);
            }

            try

            {
                Console.WriteLine(Encoding.GetEncoding("GB2312"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            try

            {
                Console.WriteLine(Encoding.GetEncoding("UTF-8"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }


        // [TestMethod]
        public async Task CallServiceTestAsync()
        {

            var manager = new TokenManger();
            var response = await manager.RequestTokenAsync();
            response.Show();

            var result = await manager.CallServiceAsync(response.AccessToken, "user/getusers");

            Console.WriteLine(result);

        }


        [TestMethod]
        public async Task CallServiceWithPasswordTestAsync()
        {

            var manager = new TokenManger();
            var response = await manager.RequestTokenWithPasswordAsync();
            response.Show();

            var result = manager.CallServiceAsync(response.AccessToken, "user/getuser?userId=2f63448e-41a5-4757-a0a7-03d1ecf30696");

            Console.WriteLine(result);
        }

    }
}
