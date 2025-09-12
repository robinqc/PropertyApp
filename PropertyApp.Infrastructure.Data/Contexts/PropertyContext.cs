using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyApp.Domain;
using PropertyApp.Infrastructure.Data.Configs;
namespace PropertyApp.Infrastructure.Data.Contexts
{
    public class PropertyContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=property_app;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PropertyConfig());
            modelBuilder.ApplyConfiguration(new OwnerConfig());
        }
    }
}

