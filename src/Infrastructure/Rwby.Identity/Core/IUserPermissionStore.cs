

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Rwby.AspNetCore.Identity
{

    public interface IUserPermissionStore<TPermission> : IPermissionStore<TPermission> where TPermission : class
    {

        Task AddToUserAsync(TPermission permission, string userId, CancellationToken cancellationToken);


        Task RemoveFromUserAsync(TPermission permission, string userId, CancellationToken cancellationToken);


        Task<IList<string>> GetUsersAsync(TPermission permission, CancellationToken cancellationToken);


        Task<bool> IsInUserAsync(TPermission permission, string userId, CancellationToken cancellationToken);


        Task<IList<TPermission>> GetPermissionsInUserAsync(string userId, long origin, CancellationToken cancellationToken);
    }
}