using ES.DAL.Models;
using ES.Utils;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ES.DAL
{
    public class ESDbContext : DbContext
    {
        public ESDbContext() {}

        public ESDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Estate> Estates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString(ConfigConstants.ESTATE_SYSTEM_DB));
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.KeyConfigs();
            base.OnModelCreating(modelBuilder);
        }
    }
}