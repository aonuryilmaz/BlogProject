using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class Category:EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public int? AuthorID { get; set; }
        public virtual Author Author { get; set; }

        public virtual List<Article_Category> ArticleCategories { get; set; }

    }
}
