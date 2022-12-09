using Domain;
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

        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(
                category =>
                {
                    category.HasKey(category => category.Id);

                    category.Property(category => category.Id).HasColumnName("id");
                    category.Property(category => category.Name).HasColumnName("name");
                });

            modelBuilder.Entity<Item>(
                item =>
                {
                    item.HasKey(item => item.Id);

                    item.Property(item => item.Id).HasColumnName("id");
                    item.Property(item => item.Name).HasColumnName("name");
                    item.Property(item => item.Price100gr).HasColumnName("price_100gr");
                    item.Property(item => item.PriceKg).HasColumnName("price_kg");
                    item.Property(item => item.CategoryId).HasColumnName("id_category");

                    item.HasOne(item => item.Category)
                        .WithMany();
                });
        }

        #endregion OnModelCreating
    }
}