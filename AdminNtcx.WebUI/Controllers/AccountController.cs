using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminNtcx.WebUI.Infrastructure.Abstract;
using AdminNtcx.WebUI.Models;


namespace AdminNtcx.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;

        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // Login View
        public ViewResult Login()
        {
            return View();
        }

        // Login Sign in
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if( ModelState.IsValid)
            {
               if(authProvider.Authenticate(model.UserName, model.Password))
               {
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
               }
               else
               {
                    ModelState.AddModelError("", "错误的用户名或密码！");
                    return View();
               }
            }
            else
            {
                return View();
            }
        }
    }
}