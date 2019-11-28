using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StaffApp.Data
{
    public class StaffDb : DbContext
    {
        public DbSet<Invoice> Invoices { get; set;}
        public DbSet<Permission> Permissions { get; set;}
        public DbSet<PriceHistory> PriceHistories { get; set;}
        public DbSet<ProductRequest> ProductRequests { get; set;}
        public DbSet<Product> Products { get; set;}
        public DbSet<StaffAccount> StaffAccounts { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set;}

        public StaffDb(DbContextOptions<StaffDb> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>(x =>
            {
                
            });

            modelBuilder.Entity<Permission>(x =>
            {
                
            });

            modelBuilder.Entity<PriceHistory>(x =>
            {

            });

            modelBuilder.Entity<Product>(x =>
            {
                x.Property(p => p.Name).IsRequired();
                x.Property(p => p.Description).IsRequired();
            });

            modelBuilder.Entity<ProductRequest>(x =>
            {

            });

            modelBuilder.Entity<StaffAccount>(x =>
            {

            });

            modelBuilder.Entity<UserAccount>(x =>
            {

            });
        }
    }
}
