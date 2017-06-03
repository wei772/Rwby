using Microsoft.EntityFrameworkCore;
using Rwby.Users.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.Users.Service
{
    public class UsersContext : DbContext
    {
        public UsersContext()
        {
        }

        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().ToTable("AspNetUsers");
        }

    }
}
