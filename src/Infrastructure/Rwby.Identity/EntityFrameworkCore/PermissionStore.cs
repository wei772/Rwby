using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.ComponentModel;

namespace Rwby.AspNetCore.Identity
{


    public class PermissionStore<TKey, TPermission, TContext,
        TRole, TUser, TUserRole
        , TRolePermission, TUserPermission>

        : IRolePermissionStore<TPermission>
       , IUserPermissionStore<TPermission>
        where TUser : IdentityUser<TKey>, new()
        where TContext : DbContext
        where TPermission : IdentityPermission<TKey>, new()
        where TRolePermission : IdentityRolePermission<TKey>, new()
        where TUserPermission : IdentityUserPermission<TKey>

        where TRole : IdentityRole<TKey>
        where TUserRole : IdentityUserRole<TKey>

        where TKey : IEquatable<TKey>
    {

        private bool _disposed;

        public TContext Context { get; private set; }

        public DbSet<TUser> UsersSet { get { return Context.Set<TUser>(); } }
        public DbSet<TRole> Roles { get { return Context.Set<TRole>(); } }
        public DbSet<TUserRole> UserRoles { get { return Context.Set<TUserRole>(); } }

        public DbSet<TPermission> Permissions { get { return Context.Set<TPermission>(); } }
        public DbSet<TRolePermission> RolePermissions { get { return Context.Set<TRolePermission>(); } }
        public DbSet<TUserPermission> UserPermissions { get { return Context.Set<TUserPermission>(); } }


        public bool AutoSaveChanges { get; set; } = true;


        public PermissionErrorDescriber ErrorDescriber { get; set; }



        public PermissionStore(TContext context, PermissionErrorDescriber describer = null)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            Context = context;

            if (describer == null)
            {
                describer = new PermissionErrorDescriber();
            }
            ErrorDescriber = describer;
        }

        #region IPermissionStore


        public Task<TPermission> FindByIdAsync(string permissionId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            var id = ConvertIdFromString(permissionId);
            return Permissions.FindAsync(new object[] { id }, cancellationToken);
        }


        public async Task<IList<TPermission>> GetUserPermissionAsync(string userId, long origin, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            var user = ConvertIdFromString(userId);

            var userQuery = from userPermission in UserPermissions
                            join permission in Permissions on userPermission.PermissionId equals permission.Id
                            where userPermission.UserId.Equals(user) && (permission.Origin == origin || permission.Origin == 0)
                            select permission;

            var userPermissions = await userQuery.ToListAsync();


            var userRoleQuery = from userRole in UserRoles
                                join rolePermission in RolePermissions on userRole.RoleId equals rolePermission.RoleId
                                join permission in Permissions on rolePermission.PermissionId equals permission.Id
                                where userRole.UserId.Equals(user) && (permission.Origin == origin || permission.Origin == 0)
                                select permission;

            var userRolePermissions = await userRoleQuery.ToListAsync();


            return userPermissions
                .Union(userRolePermissions, new PermissonEqualityComparer<TPermission, TKey>())
                .ToList();

        }



        public virtual async Task<IdentityResult> CreateAsync(TPermission permission, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
            Context.Add(permission);
            await SaveChanges(cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(TPermission permission, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
            Context.Remove(permission);
            try
            {
                await SaveChanges(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                return IdentityResult.Failed(ErrorDescriber.DefaultError());
            }
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(TPermission permission, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (permission == null)
            {
                throw new ArgumentNullException(nameof(permission));
            }
            Context.Attach(permission);
            Context.Update(permission);
            try
            {
                await SaveChanges(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                return IdentityResult.Failed(ErrorDescriber.DefaultError());
            }
            return IdentityResult.Success;
        }

        #endregion

        #region role

        public Task AddToRoleAsync(TPermission permission, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(TPermission permission, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(TPermission permission, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(TPermission permission, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TPermission>> GetPermissionsInRoleAsync(string roleName, long origin, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region user

        public Task AddToUserAsync(TPermission permission, string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromUserAsync(TPermission permission, string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetUsersAsync(TPermission permission, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInUserAsync(TPermission permission, string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TPermission>> GetPermissionsInUserAsync(string userId, long origin, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            var user = ConvertIdFromString(userId);

            var query = from userPermission in UserPermissions
                        join permission in Permissions on userPermission.PermissionId equals permission.Id
                        where userPermission.UserId.Equals(user) && (permission.Origin == origin || permission.Origin == 0)
                        select permission;

            return await query.ToListAsync();
        }

        #endregion


        #region helper


        /// <summary>
        /// Converts the provided <paramref name="id"/> to a strongly typed key object.
        /// </summary>
        /// <param name="id">The id to convert.</param>
        /// <returns>An instance of <typeparamref name="TKey"/> representing the provided <paramref name="id"/>.</returns>
        public virtual TKey ConvertIdFromString(string id)
        {
            if (id == null)
            {
                return default(TKey);
            }
            return (TKey)TypeDescriptor.GetConverter(typeof(TKey)).ConvertFromInvariantString(id);
        }


        private async Task SaveChanges(CancellationToken cancellationToken)
        {
            if (AutoSaveChanges)
            {
                await Context.SaveChangesAsync(cancellationToken);
            }
        }

        public void Dispose()
        {
            _disposed = true;
        }

        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        public Task<TPermission> FindByNameAsync(string name, long origin, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TPermission>> GetUserPermissionAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}