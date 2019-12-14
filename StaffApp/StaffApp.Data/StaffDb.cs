using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StaffApp.Data
{
    public class StaffDb : DbContext
    {
        public DbSet<Invoice> Invoices { get; set;}
        public DbSet<Permissions> Permissions { get; set;}
        public DbSet<PriceHistory> PriceHistories { get; set;}
        public DbSet<ProductRequest> ProductRequests { get; set;}
        public DbSet<Product> Products { get; set;}
        public DbSet<StaffAccount> StaffAccounts { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set;}
        public DbSet<Order> Orders { get; set; }

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
                x.Property(i => i.AccountId).IsRequired();
                x.Property(i => i.Invoiced).IsRequired();
            });

            modelBuilder.Entity<Permissions>(x =>
            {
                x.Property(p => p.CanAlterCustomers).IsRequired();
                x.Property(p => p.CanAlterStaff).IsRequired();
                x.Property(p => p.CanApproveDenyRequest).IsRequired();
                x.Property(p => p.CanDeleteCustomers).IsRequired();
                x.Property(p => p.CanHideReviews).IsRequired();
                x.Property(p => p.CanOrder).IsRequired();
                x.Property(p => p.CanOrderNewStock).IsRequired();
                x.Property(p => p.CanSetResellPrice).IsRequired();
                x.Property(p => p.CanViewCustomers).IsRequired();
                x.Property(p => p.CanViewOrders).IsRequired();
            });

            modelBuilder.Entity<PriceHistory>(x =>
            {
                x.Property(p => p.EffectiveFrom).IsRequired();
                x.Property(p => p.price).IsRequired();
            });

            modelBuilder.Entity<Product>(x =>
            {
                x.Property(p => p.Name).IsRequired();
                x.Property(p => p.Description).IsRequired();
                x.Property(p => p.StockLevel).IsRequired();
                x.HasOne(p => p.Price).WithMany()
                                      .IsRequired();
            });

            modelBuilder.Entity<ProductRequest>(x =>
            {
                x.Property(p => p.Price).IsRequired();
                x.Property(p => p.ProductName).IsRequired();
                x.Property(p => p.Quantity).IsRequired();
            });

            modelBuilder.Entity<StaffAccount>(x =>
            {
                x.Property(s => s.Forename).IsRequired();
                x.HasOne(s => s.Permission).WithMany()
                                           .HasForeignKey(s => s.PermissionId)
                                           .IsRequired();
                x.Property(s => s.Surname).IsRequired();
            });

            modelBuilder.Entity<UserAccount>(x =>
            {
                x.Property(u => u.Email).IsRequired();
                x.Property(u => u.Surname).IsRequired();
                x.Property(u => u.Forename).IsRequired();
                x.HasOne(u => u.Permission).WithMany()
                                           .HasForeignKey(u => u.PermissionsId)
                                           .IsRequired();
            });

            modelBuilder.Entity<Order>(x =>
            {
                x.Property(o => o.Cost).IsRequired();
                x.Property(o => o.Quantity).IsRequired();
                x.HasOne(o => o.Products).WithMany()
                                         .HasForeignKey(o => o.ProductId)
                                         .IsRequired();
            });
        }
    }
}
