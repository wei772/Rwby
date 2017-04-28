using Microsoft.EntityFrameworkCore;
using Rwby.User.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rwby.User.Service
{
    public class UserContext : DbContext
    {
        public UserContext()
        {
        }

        public UserContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .ToTable("User")
                .HasKey(u => u.UserId);


        }

    }
}
