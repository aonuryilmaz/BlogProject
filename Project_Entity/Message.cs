using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class Message:EntityBase
    {

        public string Phone { get; set; }
        public string ContactName { get; set; }
        public string ContactContent { get; set; }
        public string ContactEMail { get; set; }
        public string ReplyTitle { get; set; }
        public string ReplyContent { get; set; }
       
    }
}
