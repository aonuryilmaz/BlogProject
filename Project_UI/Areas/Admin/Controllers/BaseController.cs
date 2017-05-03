using Project_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {

        public ManagerProvider Manager;
        public BaseController()
        {
            Manager = new ManagerProvider();
        }
    }
}