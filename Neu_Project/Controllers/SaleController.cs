using BusinessLayer;
using System.Web.Mvc;
namespace Neu_Project.Controllers
{
    public class SaleController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.CtgCount = NEUComponent.Instance.CategoryService.Count();
            ViewBag.PrdCount = NEUComponent.Instance.ProductService.Count();
            ViewBag.UserCnt = NEUComponent.Instance.UserService.Count();
            return View();
        }
        public ActionResult SaleScreen()
        {
            return View();
        }
        public  void AddItemToChart(int id,int quantity)
        {
           
        }
    }
}