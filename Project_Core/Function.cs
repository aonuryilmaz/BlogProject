using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Eklendi
using System.Web;

namespace Project_Core
{
  public static  class Function
    {

        public static  string UploadImage(HttpPostedFileBase _document)
        {
            string fileName = _document.FileName;
            string path = HttpContext.Current.Server.MapPath("~/Areas/Admin/Content/Image/" + fileName);
            _document.SaveAs(path);
            return "~/Areas/Admin/Content/Image/" + fileName;
        }
    }
}
