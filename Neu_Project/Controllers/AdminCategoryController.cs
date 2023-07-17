using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;

namespace Neu_Project.Controllers
{
    
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
      readonly  CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [HttpGet]
        public ActionResult Index()
        {
			var CategoryValues = cm.GetAllBl();
			return View(CategoryValues);
		}
       /*public ActionResult GetList()
        {
			
		}*/
    }
}