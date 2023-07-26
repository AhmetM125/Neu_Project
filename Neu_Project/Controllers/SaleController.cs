using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
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
            var SaleList = NEUComponent.Instance.ProductService.GetAllBl();
            return View(SaleList);
        }
        public PartialViewResult _SalePopup()
        {
           
            List<SelectListItem> product = (from x in NEUComponent.Instance.ProductService.List()
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.ProductId.ToString(),
                                            }

                                        ).ToList();
            ViewBag.dgr = product;
            return PartialView();
        }
    }
}