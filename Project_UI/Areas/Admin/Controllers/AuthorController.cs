using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    public class AuthorController : BaseController
    {
        // GET: Admin/Author
        public ActionResult Index()
        {
            return View(Manager.AuthorManager.GetAll());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Author _author)
        {
            if (ModelState.IsValid)
            {
                if (_author.ConfirmPassword == _author.Password)
                {
                    Manager.AuthorManager.Add(_author);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Parolalar uyuşmamaktadır";
                    return View();
                }

            }
            else
            {
                return View();
            }

        }

        public ActionResult Edit(int ID)
        {
            Author _author = Manager.AuthorManager.GetByID(ID);
            return View(_author);
        }


        [HttpPost]
        public ActionResult Edit(Author _author)
        {
            if (ModelState.IsValid)
            {
                if (_author.ConfirmPassword == _author.Password)
                {
                    Manager.AuthorManager.Edit(_author);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Parolalar uyuşmamaktadır";
                    return View();
                }

            }
            else
            {
                return View();
            }

        }

        public ActionResult Remove(int ID)
        {
            Manager.AuthorManager.Remove(ID);
            return Json(" ");
        }

        public ActionResult Status(int ID)
        {
            return Json(Manager.AuthorManager.Status(ID));
        }

    }
}