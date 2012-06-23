using System.Web.Mvc;
using System.Web.Security;
using Zork.Core;
using Zork.Web.Models;

namespace Zork.Web.Controllers
{
    // To code readers: I am not responsible for this code
    // Visual Studio generated it
    // I'm trying hard to make it better, but give me some time
    public class AccountController : Controller
    {
        private readonly IUserValidator userValidator;

        public AccountController()
        {
            userValidator = new DatabaseUserValidator();
        }

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            if (userValidator.IsValid(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (IsRedirectable(returnUrl)) 
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private bool IsRedirectable(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                   && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\");
        }

    }

}
