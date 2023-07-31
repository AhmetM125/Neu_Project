using BusinessLayer.Abstract;
using BusinessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
     public class StockEntryManager : Repository<StockEntry>, IStockEntry
    {
        public List<StockEntry> GetAllBl() => base.List();
        
    }
}
