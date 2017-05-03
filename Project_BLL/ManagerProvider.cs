using Project_BLL.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BLL
{
    public class ManagerProvider:IDisposable
    {
        private AboutManager _aboutManager;

        public AboutManager AboutManager
        {
            get { return _aboutManager ?? new AboutManager(); }
        
        }

        private CategoryManager _categoryManager;

        public CategoryManager CategoryManager
        {
            get { return _categoryManager ?? new CategoryManager(); }
        }

        private ArticleManager _articleManager;
        public ArticleManager ArticleManager
        {
            get { return _articleManager ?? new ArticleManager(); }
        }

        private TagManager _tagManager;
        public TagManager TagManager
        {
            get { return _tagManager ?? new TagManager(); }
        }

        private AuthorManager _authorManager;

        public AuthorManager AuthorManager
        {
            get { return _authorManager ?? new AuthorManager(); }
        }

        private ContactManager _contactManager;

        public ContactManager ContactManager
        {
            get { return _contactManager ?? new ContactManager(); }
        }
        public void Dispose()
        {
           
            GC.SuppressFinalize(this);
        }
    }
}
