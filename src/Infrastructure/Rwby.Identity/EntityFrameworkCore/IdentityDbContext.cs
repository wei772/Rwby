using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Rwby.AspNetCore.Identity
{


    public abstract class IdentityDbContext<TUser, TRole, TKey, TPermission, TRolePermission, TUserPermission> :
    IdentityDbContext<TUser, TRole, TKey, IdentityUserClaim<TKey>, IdentityUserRole<TKey>, IdentityUserLogin<TKey>, IdentityRoleClaim<TKey>, IdentityUserToken<TKey>, TPermission, TRolePermission, TUserPermission>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TPermission : IdentityPermission<TKey>
        where TRolePermission : IdentityRolePermission<TKey>
        where TUserPermission : IdentityUserPermission<TKey>
    {
        public IdentityDbContext(DbContextOptions options) : base(options) { }
    }


    public abstract class IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TPermission, TRolePermission, TUserPermission> : DbContext

        where TUser : IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin>
        where TRole : IdentityRole<TKey, TUserRole, TRoleClaim>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>

        where TPermission : IdentityPermission<TKey>
        where TRolePermission : IdentityRolePermission<TKey>
        where TUserPermission : IdentityUserPermission<TKey>
    {


        public IdentityDbContext(DbContextOptions options) : base(options) { }


        public virtual DbSet<TPermission> Permissions { get; set; }
        public virtual DbSet<TUserPermission> UserPermissions { get; set; }
        public virtual DbSet<TRolePermission> RolePermissions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TPermission>(b =>
            {
                b.HasKey(r => r.Id);
                b.HasIndex(r => new { r.Name, r.Origin }).HasName("PermissionNameIndex").IsUnique();

                b.ToTable("Permissions");

                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.Name).HasMaxLength(256);

                b.HasMany<TRolePermission>().WithOne().HasForeignKey(ur => ur.PermissionId).IsRequired();
                b.HasMany<TUserPermission>().WithOne().HasForeignKey(rc => rc.PermissionId).IsRequired();
            });


            builder.Entity<TUserPermission>(b =>
            {
                b.HasKey(rc => rc.Id);
                b.ToTable("UserPermissions");
            });


            builder.Entity<TRolePermission>(b =>
            {
                b.HasKey(rc => rc.Id);
                b.ToTable("RolePermissions");
            });


        }

    }


}