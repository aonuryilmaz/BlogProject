using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity
{
   public class Author:EntityBase
    {
        [Required(ErrorMessage ="*Zorunlu Alan")]
        public string Name { get; set; }
        [Required(ErrorMessage ="*Zorunlu Alan")]
        public string Surname { get; set; }
       
        [Required(ErrorMessage = "*Zorunlu Alan")]
        [EmailAddress(ErrorMessage ="Uygun Formatta bilgi giriniz.")]
        public string EMail { get; set; }
        [NotMapped]
        public string FullName { get { return Name + " " + Surname; } }

        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public virtual List<Tag> Tags { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Article> Articles { get; set; }

        public virtual List<About> About { get; set; }
    }
}
