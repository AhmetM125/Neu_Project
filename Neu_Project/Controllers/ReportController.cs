using BusinessLayer;
using System.Web.Mvc;

namespace Neu_Project.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult SaleList()
        {
            var SaleList = NEUComponent.Instance.ProductSaleService.GetAllBl();
            return View(SaleList);
        }
        public ActionResult StockEntryList()
        {
            var StockEntryList = NEUComponent.Instance.StockEntry.GetAllBl();
            return View(StockEntryList);
        }
    }
}