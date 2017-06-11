

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rwby.AspNetCore.Identity
{

    public interface IRolePermissionStore<TPermission> : IPermissionStore<TPermission> where TPermission : class
    {
       
        Task AddToRoleAsync(TPermission permission, string roleName, CancellationToken cancellationToken);

        Task RemoveFromRoleAsync(TPermission permission, string roleName, CancellationToken cancellationToken);
       
        Task<IList<string>> GetRolesAsync(TPermission permission, CancellationToken cancellationToken);
     
        Task<bool> IsInRoleAsync(TPermission permission, string roleName, CancellationToken cancellationToken);

        Task<IList<TPermission>> GetPermissionsInRoleAsync(string roleName, long origin, CancellationToken cancellationToken);
    }
}