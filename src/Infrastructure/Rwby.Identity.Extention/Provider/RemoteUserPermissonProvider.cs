using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Rwby.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rwby.AspNetCore.Identity
{
    /// <summary>
    /// how to call remote ,may need authorization
    /// </summary>
    public class RemoteUserPermissonProvider : IUserPermissonProvider
    {
        private RemoteUserPermissonOptions _options;

        private IHttpContextAccessor _httpContextAccesor;

        private IHttpClient _HttpClient;

        public RemoteUserPermissonProvider(RemoteUserPermissonOptions options, IHttpContextAccessor httpContextAccesor, IHttpClient httpClient)
        {
            _httpContextAccesor = httpContextAccesor;
            _options = options;
            _HttpClient = httpClient;
        }

        public async Task<IEnumerable<string>> GetUserPermissionAsync(string userId, long origin)
        {
            //TODO : add internal authprize
            var userToken = await GetUserTokenAsync();

            var api = string.Format($"{_options.ApiUrl}?userId={userId}&origin={origin}");

            var jsonResult = await _HttpClient.GetStringAsync(api, userToken);

            var array = JArray.Parse(jsonResult);

            return array.Select((o => (string)((JObject)o).GetValue("NormalizedName")));
        }


        async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccesor.HttpContext;
            return await context.Authentication.GetTokenAsync("access_token");
        }
    }
}
