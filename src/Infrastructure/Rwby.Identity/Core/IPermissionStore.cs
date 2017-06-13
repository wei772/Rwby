using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Threading;

namespace Rwby.AspNetCore.Identity
{
    public interface IPermissionStore<TPermission> : IDisposable where TPermission : class
    {
        Task<TPermission> FindByIdAsync(string permissionId, CancellationToken cancellationToken);

        Task<TPermission> FindByNameAsync(string normalizedName, long origin, CancellationToken cancellationToken);

        Task<IList<TPermission>> GetUserPermissionAsync(string userId, long origin, CancellationToken cancellationToken);

        Task<IdentityResult> CreateAsync(TPermission permission, CancellationToken cancellationToken);

        Task<IdentityResult> DeleteAsync(TPermission permission, CancellationToken cancellationToken);

        Task<IdentityResult> UpdateAsync(TPermission permission, CancellationToken cancellationToken);

    }
}