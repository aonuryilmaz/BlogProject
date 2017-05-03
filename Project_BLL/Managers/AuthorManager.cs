using Project_Entity;
using Project_Entity.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BLL.Managers
{
   public class AuthorManager:ManagerBase<Author>
    {
        public Author GetCurrentUser(string _userName)
        {
            return Database.Authors.Where(x => x.EMail == _userName).FirstOrDefault();
        }

        public bool LoginUser(LoginVM _user)
        {
            return Database.Authors.Any(x => x.EMail == _user.EMail && x.Password == _user.Password && x.IsActive==true && x.IsDelete==false);
        }



    }
}
