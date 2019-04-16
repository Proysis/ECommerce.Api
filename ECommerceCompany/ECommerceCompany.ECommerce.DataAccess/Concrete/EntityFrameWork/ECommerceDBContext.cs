using System;
using System.Collections.Generic;
using System.Text;
using ECommerceCompany.ECommerce.Entity.Concrete;
using ECommerceCompany.ECommerce.Entity.Concrete.Tables;
using ECommerceCompany.ECommerce.Entity.Concrete.Views;
using Microsoft.EntityFrameworkCore;

namespace ECommerceCompany.ECommerce.DataAccess.Concrete.EntityFrameWork
{
    public class ECommerceDBContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=207.154.248.28;Database=ECommerceDB; User ID=sa; Password=a-85500157.B;");
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductBasket> ProductBasket { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<VwProductCategories> VwProductCategories { get; set; }
        public DbSet<VwCategoryProducts> VwCategoryProducts { get; set; }
        public DbSet<VwProductBasket> VwProductBasket { get; set; }
        public DbSet<VwOrderDetail> VwOrderDetail { get; set; }
        public DbSet<VwOrder> VwOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(e => new { e.ProductId, e.CategoryId });
            modelBuilder.Entity<ProductBasket>().HasKey(e => new { e.ProductId, e.BasketId });
            modelBuilder.Entity<VwProductBasket>().HasKey(e => new { e.ProductId, e.BasketId });
        }

    }
}
