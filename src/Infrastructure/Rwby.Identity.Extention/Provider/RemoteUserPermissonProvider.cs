using Microsoft.Extensions.Options;
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
        private IOptions<RemoteUserPermissonOptions> _options;

        public RemoteUserPermissonProvider(IOptions<RemoteUserPermissonOptions> options)
        {
            _options = options;
        }

        public async Task<IEnumerable<string>> GetUserPermissionAsync(string userId, long origin)
        {
            throw new NotImplementedException();
            // return (await _permissonManager.GetUserPermissionAsync(userId, origin)).Select(o => o.NormalizedName);
        }
    }
}
