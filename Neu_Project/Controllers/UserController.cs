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
    public class UserController : Controller
    {
        UserManager Um= new UserManager(new EfUserDal());
        // GET: User
        public ActionResult Index()
        {
            var UserValues = Um.GetUsers();
            return View(UserValues);
        }
        public ActionResult ChangeStatus(int Id)
        {
            var Uservalue = Um.GetById(Id);
            Uservalue.Status = Uservalue.Status == "Active" ? "Pasive" : "Active";
			Um.UserRemoveBl(Uservalue);
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
            if(result.IsValid)
            {
                Um.UserAddBl(u);
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