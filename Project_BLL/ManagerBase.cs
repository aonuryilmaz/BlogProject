using Project_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Project_Core;
using Project_DAL;
using System.Data.Entity;

namespace Project_BLL
{
    public class ManagerBase<T> : IBusiness<T> where T : EntityBase
    {
        public ProjectContext Database;

        public DbSet<T> _db;

        public ManagerBase()
        {
            Database = new ProjectContext();
            _db = Database.Set<T>();
        }

        public void Save()
        {
            Database.SaveChanges();
        }

        public void Add(T entity)
        {

            entity.CreatedDate = DateTime.Now;
            entity.IsDelete = false;
            _db.Add(entity);
            Save();
        }

        public void Edit(T entity)
        {
            var _entity = GetByID(entity.ID);
            DateTime _date = _entity.CreatedDate;
            Database.Entry(_entity).CurrentValues.SetValues(entity);
            _entity.IsDelete = false;
            _entity.UpdatedDate = DateTime.Now;
            _entity.CreatedDate = _date;
            Save();

        }

        public List<T> GetAll()
        {
            return _db.Where(x => x.IsDelete == false).ToList();
        }

        public List<T> GetAllLambda(Expression<Func<T, bool>> lambda)
        {
            return _db.Where(lambda).ToList();
        }

        public T GetByID(int ID)
        {
            return _db.Find(ID);
        }

        public void Remove(int ID)
        {
            var entity = GetByID(ID);
            entity.IsActive = false;
            entity.IsDelete = true;
            entity.DeletedDate = DateTime.Now;
            Save();
        }



        public bool Status(int ID)
        {
            var entity = GetByID(ID);
            entity.IsActive = !entity.IsActive;
            Save();
            return entity.IsActive;
        }
    }
}
