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
			ViewBag.SaleCnt = NEUComponent.Instance.ProductSaleService.TotalCount();
			return View();
		}
		public ActionResult SaleScreen(string data,string data2)
		{
			ViewBag.Error = data;
			ViewBag.Chart = data2;
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
			if (p.Quantity < Qnt || Qnt == 0)
			{
				return RedirectToAction("SaleScreen", "Sale", new { data = "Quantity Error" });
			}
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
			int Uid = (int)Session["U_Id"];
			NEUComponent.Instance.ChartService.DeleteChartProduct(id, Uid);
			return RedirectToAction("SaleScreen");
		}
		[HttpPost]
		public ActionResult ConfirmPayment(Sale s)
		{
			bool IsAnyFromList = NEUComponent.Instance.ChartService.GetAllBl((int)Session["U_Id"]).Any();
			if (IsAnyFromList)
			{
				NEUComponent.Instance.ProductSaleService.PaymentProcess(s, (int)Session["U_Id"]);
				return RedirectToAction("SaleScreen", "Sale");

			}
			else
			{
				return RedirectToAction("SaleScreen", "Sale", new { data2 = "Chart is Empty" });
			}
		}
	}
}


