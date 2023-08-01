using BusinessLayer;
using EntityLayer.Concrete;
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
			var ChartValue = NEUComponent.Instance.StockEntryChart.GetAllChart();
			return PartialView(ChartValue);
		}
		public ActionResult ProductEntry()
		{
			return View();
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
		public ActionResult ConfirmEntry(StockEntry stockEntry)
		{
			stockEntry.UserId = (int)Session["U_Id"];
			var Product = NEUComponent.Instance.ProductService.GetById(stockEntry.ProducId);
			stockEntry.ProducId = Product.ProductId;
			NEUComponent.Instance.StockEntry.Insert(stockEntry);
			return View("Index");
		}
	}
}