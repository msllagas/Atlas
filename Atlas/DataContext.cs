using Atlas.Model_Classes;

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Atlas.Pages;
using System.Collections.ObjectModel;

namespace Atlas
{
    class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = dbv3.db"); 
        }


        public DbSet<CSProduct> Products { get; set; }
        public DbSet<CSCustomer> Customers { get; set; }
        public DbSet<CSDelivery> Deliveries { get; set; }
        public DbSet<CSOrderitems> Orderitems { get; set; }
        public DbSet<TopProducts> Topchosen { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CSProduct>(entity =>
            {
                // Set key for entity
                entity.HasKey(p => p.ID);
            });

            modelBuilder.Entity<CSOrderitems>()
               .HasKey(c => new { c.TrackingNumber, c.ProductID });

            base.OnModelCreating(modelBuilder);
        }

    

    }
}
