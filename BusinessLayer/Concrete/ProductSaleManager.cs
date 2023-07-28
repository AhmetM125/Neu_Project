using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ProductSaleManager : Repository<SaleProduct>, IProductSaleService
    {

        public List<SaleProduct> GetAllBl()
        {
            return base.List();
        }

        public List<SaleProduct> GetList(int id)
        {
            return base.List(x => x.User.Id == id);
        }

        public List<SaleProduct> GetList()
        {
            throw new System.NotImplementedException();
        }
      

    }
}
