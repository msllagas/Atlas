using Atlas.Model_Classes;

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace Atlas
{
    class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = deli.db"); 
        }


        public DbSet<CSProduct> Products { get; set; }
        public DbSet<CSCustomer> Customers { get; set; }
        public DbSet<CSDelivery> Deliveries { get; set; }
        public DbSet<CSDeliInfo> DeliInfos { get; set; }
    }
}
