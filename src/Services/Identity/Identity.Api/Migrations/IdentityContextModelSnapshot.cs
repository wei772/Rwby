using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Rwby.Identity.Service;

namespace Identity.Api.Migrations
{
    [DbContext(typeof(IdentityContext))]
    partial class IdentityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rwby.Identity.Core.AppPermission", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionName");

                    b.Property<string>("AreaName");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("ControllerName");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<long>("Origin");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Origin")
                        .IsUnique()
                        .HasName("PermissionNameIndex");

                    b.ToTable("Permissions");
                });


            modelBuilder.Entity("Rwby.Identity.Core.AppRolePermission", b =>
                {
                    b.Property<string>("RoleId");

                    b.Property<string>("PermissionId");

                    b.Property<int>("Id");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions");
                });



            modelBuilder.Entity("Rwby.Identity.Core.AppUserPermission", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("PermissionId");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserPermissions");
                });



            modelBuilder.Entity("Rwby.Identity.Core.AppRolePermission", b =>
                {
                    b.HasOne("Rwby.Identity.Core.AppPermission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rwby.Identity.Core.AppUserPermission", b =>
                {
                    b.HasOne("Rwby.Identity.Core.AppPermission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
