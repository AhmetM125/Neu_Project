using BusinessLayer;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;

using System.Linq;
using System.Web.Mvc;

namespace Neu_Project.Controllers
{
    public class AdminProductController : Controller
    {

        public ActionResult ListOfProduct()
        {
            var list = NEUComponent.Instance.ProductService.List();
            return View(list);
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            ProductValidator productValidator = new ProductValidator();
            ValidationResult validationResult = productValidator.Validate(p);
            if (validationResult.IsValid)
            {
                NEUComponent.Instance.ProductService.Insert(p);
                return RedirectToAction("ListOfProduct", "AdminProduct");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteProduct(int id)
        {
            Product p = NEUComponent.Instance.ProductService.GetById(id);
            NEUComponent.Instance.ProductService.ProductDelete(p);
            return RedirectToAction("ListOfProduct");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            List<SelectListItem> product = (from x in NEUComponent.Instance.CategoryService.List()
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.CategoryId.ToString(),
                                            }

                                         ).ToList();
            ViewBag.dgr = product;
            var ProductValue = NEUComponent.Instance.ProductService.GetById(id);
            return View(ProductValue);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {

            var ktg = NEUComponent.Instance.CategoryService.GetById(product.Category.CategoryId);
            product.CategoryId = ktg.CategoryId;
            NEUComponent.Instance.ProductService.UpdateProduct(product);
            return RedirectToAction("ListOfProduct");
        }

        public PartialViewResult _PartialProductAdd()
        {
            List<SelectListItem> product = (from x in NEUComponent.Instance.CategoryService.List()
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.CategoryId.ToString(),
                                            }

                                            ).ToList();
            ViewBag.vlc = product;
            return PartialView();
        }
    }
}