using EntityLayer.Concrete;
using System.Data.Entity;

namespace DataAccessLayer.Concrete
{
    public class NEUContext : DbContext
    {
        public NEUContext()
        {

        }
        public NEUContext(string connectionString) : base(connectionString) { }
        public DbSet<Brand> Brands { get; set; }

 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<StockEntry> StockEntries { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<SaleCart> SaleCarts { get; set; }
       

    }
}
