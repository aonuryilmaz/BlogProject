using Project_Core;
using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {

        void GetCategriesTags()
        {
            ViewBag.categories = Manager.CategoryManager.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.ID.ToString()

            }).ToList();

            ViewBag.tags = Manager.TagManager.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Title,
                Value = x.ID.ToString()

            }).ToList();
        }
        // GET: Admin/Article
        public ActionResult Index()
        {
            return View(Manager.ArticleManager.GetAll());
        }

        public ActionResult Add()
        {

            GetCategriesTags();
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Add(Article _article, string[] categories, string[] tags, HttpPostedFileBase _document)

        {
            if (_document != null)
            {
                _article.ImagePath = Function.UploadImage(_document);

            }

            string createdArticle = HttpContext.User.Identity.Name;
            _article.AuthorID = Manager.AuthorManager.GetAllLambda(x => x.EMail == createdArticle).FirstOrDefault().ID;
            Manager.ArticleManager.AddArticle(_article, categories, tags);

            return RedirectToAction("Index");
        }



        public ActionResult Edit(int ID)
        {
            GetCategriesTags();
            var _article = Manager.ArticleManager.GetByID(ID);
            ViewBag.selectedTags = _article.ArticleTags.Select(x => x.TagID.ToString()).ToArray();
            ViewBag.selectedCategories = _article.ArticleCategories.Select(x => x.CategoryID.ToString()).ToArray();
            return View(_article);
        }

        [HttpPost,ValidateInput(false)]
        public ActionResult Edit(Article _article, string[] categories, string[] tags, HttpPostedFileBase _document)
        {

            string updatedArticle = HttpContext.User.Identity.Name;
            _article.AuthorID = Manager.AuthorManager.GetAllLambda(x => x.EMail == updatedArticle).FirstOrDefault().ID;
            if (_document!=null)
            {
                _article.ImagePath = Function.UploadImage(_document);
            }
            else
            {
                _article.ImagePath = Manager.ArticleManager.GetByID(_article.ID).ImagePath;
            }

            Manager.ArticleManager.EditArticle(_article, categories, tags);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int ID)
        {
            Manager.ArticleManager.Remove(ID);
            return Json(" ");

        }
        public ActionResult Status(int ID)
        {
            return Json(Manager.ArticleManager.Status(ID));
        }
    }
}