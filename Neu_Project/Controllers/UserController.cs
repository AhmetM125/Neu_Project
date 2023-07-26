using BusinessLayer;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace Neu_Project.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var UserValues = NEUComponent.Instance.UserService.GetUsers();
            return View(UserValues);
        }
        public ActionResult ChangeStatus(int Id)
        {
            var Uservalue = NEUComponent.Instance.UserService.GetById(Id);
            Uservalue.Status = Uservalue.Status == "Active" ? "Pasive" : "Active";
            NEUComponent.Instance.UserService.UserRemoveBl(Uservalue);

            return RedirectToAction("Index");
        }
        /*  [HttpGet]
          public ActionResult NewUser()
          {

          }*/
        [HttpPost]
        public ActionResult NewUser(User u)
        {
            UserValidator uservalidator = new UserValidator();
            ValidationResult result = uservalidator.Validate(u);
            if (result.IsValid)
            {
                NEUComponent.Instance.UserService.UserAddBl(u);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");

        }
        public PartialViewResult CreatePartialPopup()
        {

            return PartialView();
        }
    }
}