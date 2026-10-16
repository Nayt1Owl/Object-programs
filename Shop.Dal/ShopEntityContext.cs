using Microsoft.EntityFrameworkCore;

namespace Shop.Dal
{
    public sealed class ShopEntityContext : DbContext
    {
        public string DataSource { get; private set; }
        public DbSet<ShopDao> Shops { get; set; } = null!;
        public DbSet<GoodDao> Goods { get; set; } = null!;
        public DbSet<ClientDao> Clients { get; set; } = null!;
        public ShopEntityContext(string dataSource = "shop.db")
        {
            DataSource = dataSource;
            Database?.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DataSource}");
            }
        }
    }
}