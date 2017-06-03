using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rwby.Identity.Core;
using Rwby.Identity.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Identity.Service
{
    public class GlobalContext : IdentityDbContext<ApplicationUser>
    {
        public GlobalContext()
        {
        }

        public GlobalContext(DbContextOptions<GlobalContext> options) : base(options)
        {
        }

        //public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
