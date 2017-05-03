using Project_Entity.VM;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_UI.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Admin/Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginVM _loginUser)
        {
            if (ModelState.IsValid)
            {
              
                    if (Manager.AuthorManager.LoginUser(_loginUser))
                    {
                        FormsAuthentication.SetAuthCookie(_loginUser.EMail, true);
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                    ViewBag.error = "Kullanıcı adı veya parola yanlış";
                        return View();
                    }
           
               
            }
            else
            {
                return View();
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}