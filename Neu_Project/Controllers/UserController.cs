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
            var UserValues = NEUComponent.Instance.UserService.GetUsers(false);
            return View(UserValues);
        }
        public ActionResult ChangeStatus(int Id)
        {
            var Uservalue = NEUComponent.Instance.UserService.GetById(Id);
            Uservalue.Status = Uservalue.Status == true ? false : true;
            NEUComponent.Instance.UserService.UserRemoveBl(Uservalue);

            return RedirectToAction("Index");
        }
        public ActionResult ShowAll()
        {
            var userValues = NEUComponent.Instance.UserService.GetUsers(true);
            return View("Index", userValues);
        }
        public ActionResult DeleteU(int Id)
        {
            var Uservalue = NEUComponent.Instance.UserService.GetById(Id);
            NEUComponent.Instance.UserService.UserRemoveBl(Uservalue);
            return RedirectToAction("Index","User");    
        }
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
        public PartialViewResult UserVPartial()
        {
            return PartialView();
        }

	}
}