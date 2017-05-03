using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
  public  class Article_Tag
    {

        public int  ID { get; set; }
        public int? TagID { get; set; }
        public int? ArticleID { get; set; }
        public virtual Article Article { get; set; }
        public virtual  Tag Tag { get; set; }
    }
}
