using BusinessLayer;
using EntityLayer.Concrete;
using System;
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
			ViewBag.SaleCnt = NEUComponent.Instance.ProductSaleService.Count();
			return View();
		}
		public ActionResult SaleScreen()
		{

			int U_Id = (int)Session["U_Id"];
			var Sscreen = NEUComponent.Instance.ChartService.GetAllBl(U_Id);
			return View(Sscreen);

		}
		[HttpPost]
		public ActionResult SaleScreen(int id)
		{
			var Pvalue = NEUComponent.Instance.ProductService.GetById(id);
			return View(Pvalue);
		}
		[HttpGet]
		public ActionResult DeleteChart()
		{

			int Uid = (int)Session["U_Id"];
			NEUComponent.Instance.ChartService.ChartDelete(Uid);
			return RedirectToAction("SaleScreen", "Sale");
		}
		[HttpPost]
		public ActionResult InsertToBasket(Product p)
		{
			int uID = (int)Session["U_Id"];
			int Qnt = p.Quantity;
			SaleCart SaleCart;
			p = NEUComponent.Instance.ProductService.GetById(p.ProductId);
			p.Quantity = Qnt;
			SaleCart = NEUComponent.Instance.ChartService.SetProduct(p, uID);
			NEUComponent.Instance.ChartService.InsertChart(SaleCart);


			return RedirectToAction("SaleScreen", "Sale");
		}

		public PartialViewResult SalePopup()
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

		public PartialViewResult Prt_PaymentDetails()
		{
			int Uid = (int)Session["U_Id"];
			List<SelectListItem> SaleCart = (from x in NEUComponent.Instance.UserService.GetUsers(true)
											 select new SelectListItem
											 {
												 Text = x.Name + " " + x.Username,
												 Value = x.UserId.ToString(),
											 }).ToList();
			ViewBag.PaymentNS = SaleCart;


			ViewData["TotalPrice"] = NEUComponent.Instance.ChartService.GeneralSum();
			return PartialView();
		}
		public ActionResult RemoveProduct(int id)
		{
			NEUComponent.Instance.ChartService.DeleteChartProduct(id);
			return RedirectToAction("SaleScreen");
		}
		[HttpPost]
		public ActionResult ConfirmPayment(Sale s)
		{
			NEUComponent.Instance.ProductSaleService.PaymentProcess(s,(int)Session["U_Id"]);
			NEUComponent.Instance.ProductSaleService.ProductSaleInsert(s);
			return RedirectToAction("Index", "AdminCategory", new { data = "Success" });
		}
	}
}


