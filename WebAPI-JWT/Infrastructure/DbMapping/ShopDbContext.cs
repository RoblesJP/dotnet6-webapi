using Domain;
using Infrastructure.DbMapping.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbMapping
{
    public class ShopDbContext : DbContext
    {
        #region Sets

        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        #endregion Sets

        #region Constructor

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        #endregion Constructor

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}