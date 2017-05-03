using Project_Entity.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Controllers
{
    public class AboutController : BaseController
    {
        // GET: About
        public ActionResult Index()
        {
            AboutVM page = new AboutVM();
            page.About = Manager.AboutManager.GetAbout();
            page.Authors = Manager.AuthorManager.GetAllLambda(x => x.IsDelete == false && x.IsActive == true).OrderByDescending(x=>x.CreatedDate).Take(3).ToList();
            return View(page);
        }
    }
}