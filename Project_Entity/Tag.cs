using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class Tag:EntityBase
    {
        public string Title { get; set; }
        public int? AuthorID { get; set; }
        public virtual Author  Author { get; set; }

        public virtual List<Article_Tag> ArticleTags { get; set; }
    }
}
