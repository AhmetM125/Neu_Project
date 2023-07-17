using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete 
{
	public class Context :DbContext
	{
        public DbSet<Brand> Brands { get; set; }
		public DbSet<Category> Categories { get; set; }

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<SaleProduct> SaleProducts { get; set; }

		public DbSet<Sale> Sales { get; set; }

		public DbSet<StockEntry> StockEntries { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
