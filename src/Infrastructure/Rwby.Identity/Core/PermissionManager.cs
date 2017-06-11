using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Rwby.AspNetCore.Identity
{
    public class PermissionManager<TPermission> : IDisposable where TPermission : class
    {
        private bool _disposed;

        protected virtual CancellationToken CancellationToken => CancellationToken.None;

        protected internal IPermissionStore<TPermission> Store { get; set; }

        public IList<IPermissionValidator<TPermission>> PermissionValidators { get; } = new List<IPermissionValidator<TPermission>>();

        public PermissionErrorDescriber ErrorDescriber { get; set; }

        public PermissionOptions Options { get; set; }

        public virtual ILogger Logger { get; set; }


        public virtual bool SupportsRolePermission
        {
            get
            {
                ThrowIfDisposed();
                return Store is IRolePermissionStore<TPermission>;
            }
        }


        public virtual bool SupportsUserPermission
        {
            get
            {
                ThrowIfDisposed();
                return Store is IUserPermissionStore<TPermission>;
            }
        }


        public PermissionManager(
            IPermissionStore<TPermission> store,
            IEnumerable<IPermissionValidator<TPermission>> permissionValidators,
            IOptions<PermissionOptions> optionsAccessor,
            PermissionErrorDescriber errors,
            IServiceProvider services,
            ILogger<PermissionManager<TPermission>> logger)
        {
            Store = store;
            Options = optionsAccessor?.Value ?? new PermissionOptions();
            ErrorDescriber = errors;
            Logger = logger;

            if (permissionValidators != null)
            {
                foreach (var v in permissionValidators)
                {
                    PermissionValidators.Add(v);
                }
            }

        }

        #region IPermissionStore

        public virtual async Task<IList<TPermission>> GetUserPermissionAsync(string userId, long origin)
        {
            ThrowIfDisposed();
            var result = await Store.GetUserPermissionAsync(userId, origin, CancellationToken);
            return result;
        }


        public virtual async Task<IdentityResult> CreateAsync(TPermission permission)
        {
            ThrowIfDisposed();
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
            var result = await ValidatePermissionInternal(permission);
            if (!result.Succeeded)
            {
                return result;
            }
            result = await Store.CreateAsync(permission, CancellationToken);
            return result;
        }


        public virtual Task<IdentityResult> UpdateAsync(TPermission permission)
        {
            ThrowIfDisposed();
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            return UpdatePermissionAsync(permission);
        }

        /// <summary>
        /// Deletes the specified <paramref name="role"/>.
        /// </summary>
        /// <param name="role">The role to delete.</param>
        /// <returns>
        /// The <see cref="Task"/> that represents the asynchronous operation, containing the <see cref="IdentityResult"/> for the delete.
        /// </returns>
        public virtual Task<IdentityResult> DeleteAsync(TPermission permission)
        {
            ThrowIfDisposed();
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            return Store.DeleteAsync(permission, CancellationToken);
        }


        #endregion


        #region IRolePermissionStore


        public virtual async Task AddToRoleAsync(TPermission permission, string normalizedRoleName)
        {
            ThrowIfDisposed();
            var roleStore = GetRolePermissionStore();

            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }

            await roleStore.AddToRoleAsync(permission, normalizedRoleName, CancellationToken);
        }


        private IRolePermissionStore<TPermission> GetRolePermissionStore()
        {
            var cast = Store as IRolePermissionStore<TPermission>;
            if (cast == null)
            {
                throw new NotSupportedException("not support rolePermissionStore");
            }
            return cast;
        }


        #endregion



        private async Task<IdentityResult> UpdatePermissionAsync(TPermission permission)
        {
            var result = await ValidatePermissionInternal(permission);
            if (!result.Succeeded)
            {
                return result;
            }
            return await Store.UpdateAsync(permission, CancellationToken);
        }


        //只能说抛异常也不是一个好方法,影响程序性能!

        private async Task<IdentityResult> ValidatePermissionInternal(TPermission permission)
        {
            var errors = new List<IdentityError>();
            foreach (var v in PermissionValidators)
            {
                var result = await v.ValidateAsync(this, permission);
                if (!result.Succeeded)
                {
                    errors.AddRange(result.Errors);
                }
            }
            if (errors.Count > 0)
            {
                //  Logger.LogWarning(0, "Role {roleId} validation failed: {errors}.", await GetRoleIdAsync(role), string.Join(";", errors.Select(e => e.Code)));
                return IdentityResult.Failed(errors.ToArray());
            }
            return IdentityResult.Success;
        }


        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                Store.Dispose();
                _disposed = true;
            }
        }

        /// <summary>
        /// Throws if this class has been disposed.
        /// </summary>
        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
        #endregion

    }


}