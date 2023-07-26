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

        public static NEUComponent Instance
        {
            get
            {
                return new NEUComponent();
            }
        }
    }
}
