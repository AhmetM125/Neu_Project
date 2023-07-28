using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}