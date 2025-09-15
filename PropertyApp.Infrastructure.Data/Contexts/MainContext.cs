using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PropertyApp.Domain;
using PropertyApp.Infrastructure.Data.Configs;
using dotenv.net;

namespace PropertyApp.Infrastructure.Data.Contexts
{
    public class MainContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var envVar = DotEnv.Read();
            var connectionString = envVar["MONGODB_CONNECTION_STRING"];
            optionsBuilder.UseMongoDB(connectionString, "PropertyAppDB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PropertyConfig());
            modelBuilder.ApplyConfiguration(new OwnerConfig());
            modelBuilder.ApplyConfiguration(new PropertyImageConfig());
        }
    }
}

