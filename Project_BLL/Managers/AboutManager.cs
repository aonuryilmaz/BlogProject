using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BLL.Managers
{
   public class AboutManager:ManagerBase<About>
    {

        public List<About> GetAbout()
        {
            return Database.Abouts.OrderByDescending(x => x.CreatedDate).Where(x => x.IsDelete == false && x.IsActive).Take(1).ToList();


        }
    }
}
