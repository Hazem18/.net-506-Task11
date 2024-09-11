using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using P01_SalesDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_SalesDatabase.Data
{
    public class ApplicationDbContext : DbContext    
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer
          ("Data Source = LAPTOP-EPP1LDGQ\\MSSQLSERVER04; Initial Catalog = MYSales ; Integrated Security = True; TrustServerCertificate = True");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Products
            modelBuilder.Entity<Product>()
                .Property(e=>e.Name).HasMaxLength(50);
            modelBuilder.Entity<Product>()
                .Property(e=>e.Quantity).HasColumnType("REAL");

            //Customers
            modelBuilder.Entity<Customer>()
                .Property(e => e.Name).HasMaxLength(100);
            modelBuilder.Entity<Customer>()
                .Property(e=>e.Email).IsUnicode(false).HasMaxLength(80);

            //Store
            modelBuilder.Entity<Store>()
                .Property(e=> e.Name).HasMaxLength(80);


         
            //Relations
            //1.Customer ---> Sales
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Sales)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //2.Product ---> Sales
            modelBuilder.Entity<Product>()
                .HasMany(e => e.Sales)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            //3.Store ---> Sales
            modelBuilder.Entity<Store>()
                .HasMany(e => e.Sales)
                .WithOne(e => e.Store)
                .HasForeignKey(e => e.StoreId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

        }
    }
}
