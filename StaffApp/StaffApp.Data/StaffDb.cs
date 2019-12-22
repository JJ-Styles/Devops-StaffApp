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
        public DbSet<Reviews> Reviews { get; set; }

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

            modelBuilder.Entity<Product>(x =>
            {
                x.Property(p => p.Name).IsRequired();
                x.Property(p => p.Description).IsRequired();
                x.Property(p => p.StockLevel).IsRequired();
            });

            modelBuilder.Entity<PriceHistory>(x =>
            {
                x.Property(p => p.EffectiveFrom).IsRequired();
                x.Property(p => p.Price).IsRequired();
                x.HasOne(p => p.product).WithMany()
                                        .HasForeignKey(p => p.ProductId)
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
                x.Property(u => u.Active).IsRequired();
                x.HasOne(u => u.Permission).WithMany()
                                           .HasForeignKey(u => u.PermissionsId)
                                           .IsRequired();
            });

            modelBuilder.Entity<Reviews>(x =>
            {
                x.Property(r => r.Rating).IsRequired();
                x.Property(r => r.Description).IsRequired();
                x.Property(r => r.Hidden);
                x.HasOne(r => r.Products).WithMany()
                                         .HasForeignKey(r => r.ProductId)
                                         .IsRequired();
                x.HasOne(r => r.User).WithMany()
                                     .HasForeignKey(r => r.UserAccountId)
                                     .IsRequired();
            });

            modelBuilder.Entity<Invoice>(x =>
            {
                x.Property(i => i.Invoiced).IsRequired();
                x.HasOne(i => i.User).WithMany()
                                     .HasForeignKey(i => i.UserAccountId)
                                     .IsRequired();
                x.HasOne(i => i.Staff).WithMany()
                                      .HasForeignKey(i => i.StaffAccountId);
            });

            modelBuilder.Entity<Order>(x =>
            {
                x.Property(o => o.Cost).IsRequired();
                x.Property(o => o.Quantity).IsRequired();
                x.Property(o => o.Dispatched).IsRequired();
                x.Property(o => o.DispatchDate);
                x.HasOne(o => o.Products).WithMany()
                                         .HasForeignKey(o => o.ProductId)
                                         .IsRequired();
                x.HasOne(o => o.Invoices).WithMany()
                                         .HasForeignKey(o => o.InvoiceId)
                                         .IsRequired();
            });
        }
    }
}
