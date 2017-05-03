using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Entity.VM
{
   public class LoginVM
    {
        [Required(ErrorMessage = "* Zorunlu Alan")]
        [EmailAddress(ErrorMessage = "* Uygun formatta bilgi giriniz")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "* Zorunlu Alan")]
        public string Password { get; set; }
    }
}
