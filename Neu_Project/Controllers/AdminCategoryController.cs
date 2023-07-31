using BusinessLayer;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace Neu_Project.Controllers
{
	public class AdminCategoryController : Controller
    {

        // GET: AdminCategory
        [HttpGet]
        public ActionResult Index(string data)
        {
            ViewBag.data = data;

            var CategoryValues = NEUComponent.Instance.CategoryService.GetAllBl();
            return View(CategoryValues);
        }
        public ActionResult DeleteCtg(int id)
        {
            Category c = NEUComponent.Instance.CategoryService.GetById(id);
            NEUComponent.Instance.CategoryService.CategoryDelete(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCtgPage(int id)
        {
            var categoryvalue = NEUComponent.Instance.CategoryService.GetById(id);
            return View(categoryvalue);
            
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            NEUComponent.Instance.CategoryService.UpdateCategory(category);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult CreateCategory()
        {


            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category c)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(c);
            if (results.IsValid)
            {
                NEUComponent.Instance.CategoryService.Insert(c);
                return RedirectToAction("Index", "AdminCategory", new { data = "Success" });

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                    return RedirectToAction("Index", "AdminCategory", new { data = "Error" });

            }
          // return RedirectToAction("Index", "AdminCategory");

        }

    }
}