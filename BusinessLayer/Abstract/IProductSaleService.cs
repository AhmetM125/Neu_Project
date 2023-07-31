using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IProductSaleService : IRepository<Sale>
    {
        List<Sale> GetAllBl();
        List<Sale> GetList();

        void ProductSaleInsert(Sale product);
        int GenerateTransactionNumber();
        void PaymentProcess(Sale sale,int Uid);
    }
}
