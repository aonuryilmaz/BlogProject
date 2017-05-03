using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    public class TagController : BaseController
    {
        // GET: Admin/Tag
        public ActionResult Index()
        {
            return View(Manager.TagManager.GetAll());
        }
        public ActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Add(Tag _tag)
        {
            Manager.TagManager.Add(_tag);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int ID)
        {              
            return View(Manager.TagManager.GetByID(ID));

        }
        [HttpPost]
        public ActionResult Edit(Tag _tag)
        {
            Manager.TagManager.Edit(_tag);
            return RedirectToAction("Index");
        }

        public ActionResult Status(int ID)
        {
            return Json(Manager.TagManager.Status(ID));
        }

        public ActionResult Remove(int ID)
        {
            Manager.TagManager.Remove(ID);
            return Json(" ");


        }
    }
}