using Project_Core;
using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(Manager.CategoryManager.GetAll());
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category _category, HttpPostedFileBase _document)
        {
            if (_document != null)
            {
                _category.ImagePath = Function.UploadImage(_document);
            }

            Manager.CategoryManager.Add(_category);
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int ID)
        {
            TempData["image"] = Manager.CategoryManager.GetByID(ID).ImagePath;
            return View(Manager.CategoryManager.GetByID(ID));
        }
        [HttpPost]
        public ActionResult Edit(Category _category,HttpPostedFileBase _document)
        {
            if (_document != null)
            {
                _category.ImagePath = Function.UploadImage(_document);
            }
            else
            {
                _category.ImagePath = TempData["image"].ToString();
            }

            Manager.CategoryManager.Edit(_category);
            return RedirectToAction("Index");
        }

        public JsonResult Remove(int ID)
        {
            Manager.CategoryManager.Remove(ID);
            return Json(" ");
        }

        public JsonResult Status(int ID)
        {
            return Json(Manager.CategoryManager.Status(ID));
        }
    }
}