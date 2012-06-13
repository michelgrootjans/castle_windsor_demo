using System;
using System.Web.Mvc;
using System.Web.Security;
using Zork.Core.Memberships;
using Zork.Web.Models;

// To code readers: I am not responsible for this code
// Visual Studio generated it
// I'm trying hard to make it better, but give me some time

namespace Zork.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMembershipProvider membershipProvider;

        public AccountController()
        {
            membershipProvider = new AlwaysOkMembershipProvider();
        }

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            if (membershipProvider.IsValidUser(model.UserName, model.Password))
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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                membershipProvider.RegisterNewUser(model.UserName, model.Password, model.Email);
                FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            }
            
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                membershipProvider.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                return RedirectToAction("ChangePasswordSuccess");
            }
            catch
            {
                ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                return View(model);
            }
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        private bool IsRedirectable(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                   && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\");
        }

    }

}
