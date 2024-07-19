﻿using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Web_TraSua_API.Model;
using System.Reflection.Metadata;

namespace Web_TraSua_API.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Roles> role { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<Bill> bill { get; set; }
        public DbSet<BillDetail> bill_detail { get; set; }
        public DbSet<Categories> category { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Size> size { get; set; }
        public DbSet<Size_Product> size_product { get; set; }
        public ICollection<SizeProduct_BillDetail> sizeProduct_billDetail { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<Image> image { get; set; }
        public DbSet<Blog> blog { get; set; }
        public DbSet<Banner> banner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(r => r.RoleID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Size_Product>()
               .HasOne(sp => sp.Product)
               .WithMany(p => p.Size_Product)
               .HasForeignKey(sp => sp.ProductID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Size_Product>()
                .HasOne(sp => sp.Size)
                .WithMany(s => s.Size_Product)
                .HasForeignKey(sp => sp.SizeID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SizeProduct_BillDetail>()
                .HasOne(sp => sp.bill_detail)
                .WithMany(s => s.sizeProduct_billDetail)
                .HasForeignKey(sp => sp.IDSizeProduct)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SizeProduct_BillDetail>()
                .HasOne(sp => sp.size_product)
                .WithMany(s => s.sizeProduct_billDetail)
                .HasForeignKey(sp => sp.IDSizeProduct)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                  .HasOne(p => p.Categories)
                  .WithMany(c => c.Products)
                  .HasForeignKey(p => p.CateID)
                  .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Image>()
                  .HasOne(i => i.Products)
                  .WithMany(i => i.Image)
                  .HasForeignKey(i => i.ProductID)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
