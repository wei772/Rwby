using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rwby.Global.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Global.Service
{
    public class GlobalContext : IdentityDbContext<UserEntity>
    {
        public GlobalContext()
        {
        }

        public GlobalContext(DbContextOptions options) : base(options)
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
