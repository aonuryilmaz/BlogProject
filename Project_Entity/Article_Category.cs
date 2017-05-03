using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class Article_Category
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public int? ArticleID { get; set; }
        public virtual Article Article { get; set; }
        public virtual Category Category { get; set; }
    }
}
