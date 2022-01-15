using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace Atlas
{
    class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = deli.db"); 
        }

        public DbSet<CSDelivery> Deliveries { get; set; }
    }
}
