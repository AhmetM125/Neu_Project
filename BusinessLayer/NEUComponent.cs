using BusinessLayer.Abstract;
using BusinessLayer.Concrete;

namespace BusinessLayer
{
    public class NEUComponent
    {
        public static string ConnectionString { get; set; }

        public ICategoryService CategoryService => new CategoryManager();
        public IProductService ProductService => new ProductManager();
        public IProductSaleService ProductSaleService => new ProductSaleManager();
        public IUserService UserService => new UserManager();
        public ISaleCart ChartService => new SaleCartManager();
        public IStockEntry StockEntry => new StockEntryManager();
        public IStockEntryChart StockEntryChart => new EntryChartManager();

		public static NEUComponent Instance
        {
            get
            {
                return new NEUComponent();
            }
        }
    }
}
