using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Controllers
{
    public class BlogController : BaseController
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View(Manager.ArticleManager.GetAllLambda(x=>x.IsActive==true && x.IsDelete==false && x.Content!=null).ToList());
        }

        public ActionResult Detail(int ID)
        {
            return View(Manager.ArticleManager.GetByID(ID));
        }
    }
}