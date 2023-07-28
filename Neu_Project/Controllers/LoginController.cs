using BusinessLayer;
using EntityLayer.Concrete;
using Neu_Project.Utility;
using System.Web.Mvc;
using System.Web.Security;

namespace Neu_Project.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {


        [HttpGet]

        public ActionResult UserLogin()
        {         
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(User u)
        {

            var userinfo = NEUComponent.Instance.UserService.Login(u.Username, u.Password);
            if (userinfo != null)
            {
                /*userinfo.Password = string.Empty;*/
                FormsAuthentication.SetAuthCookie(userinfo.Username, false);
                Session["U_Id"] = userinfo.Id;
                return RedirectToAction("Index", "AdminCategory");

            }
            else
             {
                return RedirectToAction("UserLogin", "Login");
               }

}
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("UserLogin", "Login");
        }
    }
}