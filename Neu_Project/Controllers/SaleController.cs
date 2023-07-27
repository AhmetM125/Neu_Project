using BusinessLayer;
using EntityLayer.Concrete;
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
            var Sscreen = NEUComponent.Instance.ChartService.GetAllBl();
            return View(Sscreen);
            
        }
        [HttpPost]
        public ActionResult SaleScreen(int id)
        {
            var Pvalue = NEUComponent.Instance.ProductService.GetById(id);
            return View(Pvalue);
        }
        [HttpPost]
        public ActionResult InsertToBasket(Product p)
        {
            int Qnt = p.Quantity;
            SaleCart SaleCart;
            p = NEUComponent.Instance.ProductService.GetById(p.ProductId);
            SaleCart = NEUComponent.Instance.ChartService.SetProduct(p);
            SaleCart.Quantity = Qnt;
            NEUComponent.Instance.ChartService.InsertChart(SaleCart);

            return RedirectToAction("SaleScreen", "Sale");
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