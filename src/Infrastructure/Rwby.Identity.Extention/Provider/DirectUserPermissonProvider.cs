using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rwby.AspNetCore.Identity
{
    public class DirectUserPermissonProvider<TPermission> : IUserPermissonProvider
           where TPermission : IdentityPermission
    {
        PermissionManager<TPermission> _permissonManager;

        public DirectUserPermissonProvider(PermissionManager<TPermission> permissonManager)
        {
            _permissonManager = permissonManager;
        }

        public async Task<IEnumerable<string>> GetUserPermissionAsync(string userId, long origin)
        {
            return (await _permissonManager.GetUserPermissionAsync(userId, origin)).Select(o => o.NormalizedName);
        }
    }
}
