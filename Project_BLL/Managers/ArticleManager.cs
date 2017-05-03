using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BLL.Managers
{
    public class ArticleManager : ManagerBase<Article>
    {

        public void AddArticle(Article _article, string[] categories, string[] tags)
        {
            Add(_article);

            if (categories != null)
            {
                foreach (var item in categories)
                {
                    int categoryID = Convert.ToInt32(item);
                    Article_Category _category = new Article_Category();
                    _category.CategoryID = categoryID;
                    _category.ArticleID = _article.ID;
                    Database.ArticleCategories.Add(_category);
                    Save();

                }
            }
            if (tags != null)
            {
                foreach (var item in tags)
                {
                    int tagID = Convert.ToInt32(item);
                    Article_Tag _tag = new Article_Tag();
                    _tag.TagID = tagID;
                    _tag.ArticleID = _article.ID;
                    Database.ArticleTags.Add(_tag);
                    Save();
                }
            }

        }
        public void EditArticle(Article _article, string[] categories, string[] tags)
        {
            Edit(_article);
            foreach (var tag in Database.ArticleTags.ToList())
            {
                if (tag.ArticleID==_article.ID)
                {
                    Database.ArticleTags.Remove(tag);
                    Save();
                }
            }

            foreach (var category in Database.ArticleCategories.ToList())
            {
                if (category.ArticleID==_article.ID)
                {
                    Database.ArticleCategories.Remove(category);
                    Save();
                }
            }
            if (categories != null)
            {
                foreach (var item in categories)
                {
                    int categoryID = Convert.ToInt32(item);
                    Article_Category _category = new Article_Category();
                    _category.CategoryID = categoryID;
                    _category.ArticleID = _article.ID;
                    Database.ArticleCategories.Add(_category);
                    Save();

                }
            }
            if (tags != null)
            {
                foreach (var item in tags)
                {
                    int tagID = Convert.ToInt32(item);
                    Article_Tag _tag = new Article_Tag();
                    _tag.TagID = tagID;
                    _tag.ArticleID = _article.ID;
                    Database.ArticleTags.Add(_tag);
                    Save();
                }
            }
        }

        public List<Article> GetByNewArticles()
        {
            return Database.Articles.Where(x => x.IsDelete == false && x.IsActive == true).OrderByDescending(x => x.CreatedDate).Take(2).ToList();


        }
    }
}
