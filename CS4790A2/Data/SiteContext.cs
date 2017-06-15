﻿using Microsoft.EntityFrameworkCore;
using CS4790A3.Models;

namespace CS4790A3.Data
{
    public class SiteContext : DbContext
    {

        public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {
        }

        public DbSet<Site> Sites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Site>().ToTable("Site");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Comment>().ToTable("Comment");
        }


    }
}