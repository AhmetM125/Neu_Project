using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using Microsoft.Ajax.Utilities;

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
      public ActionResult DeleteCtg(int id)
        {
            var category = cm.GetById(id);
            cm.CategoryDelete(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCtgPage(int id)
        {
            var categoryvalue = cm.GetById(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
           cm.UpdateCategory(category);
           return RedirectToAction("Index");
            
        }
    }
}