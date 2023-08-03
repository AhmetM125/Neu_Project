using BusinessLayer;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Neu_Project.Controllers
{
	public class StockEntryController : Controller
	{
		// GET: StockEntry
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult TransactionEntry()
		{
			return View();
		}
		public ActionResult PList()
		{
			var Plist = NEUComponent.Instance.StockEntry.GetAllBl();
			return View(Plist);
		}
		public PartialViewResult ChartList()
		{
			ViewBag.Total = NEUComponent.Instance.StockEntryChart.CalculateTotal((int)Session["U_Id"]);
			var ChartValue = NEUComponent.Instance.StockEntryChart.GetAllChart((int)Session["U_Id"]);
			return PartialView(ChartValue);
		}
		public ActionResult DeleteChart()
		{
			NEUComponent.Instance.StockEntryChart.DeleteEntryChart((int)Session["U_Id"]);
			return RedirectToAction("Index", "StockEntry");
		}
		public ActionResult ProductEntry()
		{
			return View();
		}
		public ActionResult DeleteProduct(int id)
		{
			NEUComponent.Instance.StockEntryChart.DeleteW(x => x.ProductId == id);
			return RedirectToAction("Index", "StockEntry");
		}
		[HttpGet]
		public ActionResult EditProduct(int id)
		{
			EntryCart e = NEUComponent.Instance.StockEntryChart.Get(x => x.ProductId == id);
			return View(e);
		}
		[HttpPost]
		public ActionResult EditProduct(EntryCart e)
		{
			int Quantity = (int)e.Quantity;
			e = NEUComponent.Instance.StockEntryChart.Get(x => x.ProductId == e.ProductId);
			e.Quantity = Quantity;
			NEUComponent.Instance.StockEntryChart.Update(e);
			return RedirectToAction("Index", "StockEntry");
		}
		public PartialViewResult ProductEntryP()
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
		[HttpPost]
		public ActionResult ConfirmEntryToBasket(Product p)
		{
			int Quantity = p.Quantity;
			var Product = NEUComponent.Instance.ProductService.GetById(p.ProductId);
			Product.Quantity = Quantity;

			StockEntryValidator rules = new StockEntryValidator(p);
			ValidationResult validationResult = rules.Validate(p);

			if (validationResult.IsValid)
			{
				int Uid = (int)Session["U_Id"];
				if (NEUComponent.Instance.StockEntryChart.InsertToBasket(Product, Uid, Quantity))
					return RedirectToAction("Index", "StockEntry");

			}
			return RedirectToAction("Index", "StockEntry");
		}
		[HttpPost]
		public ActionResult ConfirmEntry()
		{
			NEUComponent.Instance.StockEntry.ConfirmEntry((int)Session["U_Id"]);
			return RedirectToAction("Index", "StockEntry");
		}
	}
}