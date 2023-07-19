using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Neu_Project.Controllers
{
    public class AdminProductController : Controller
    {

		readonly ProductManager pm = new ProductManager(new EfProductDal());
        
		public ActionResult ListOfProduct()
		{
			var productvalues = pm.GetAllBl();
			return View(productvalues);
		}
		[HttpPost]
		public ActionResult AddProduct(Product p)
		{
			ProductValidator productValidator = new ProductValidator();
			ValidationResult validationResult = productValidator.Validate(p);
			if(validationResult.IsValid)
			{
				pm.ProductAddBl(p);
				return RedirectToAction("ListOfProduct");
			}
			else
			{
				foreach(var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);	
				}
			}
			return View();
		}


		[HttpGet]
		public ActionResult AddProduct()
		{
			return View();
		}
	}
}