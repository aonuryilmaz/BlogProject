using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project_Core
{
  public interface IBusiness<T>
    {
        void Save();
        void Add(T entity);
        void Edit(T entity);
        void Remove(int ID);

        bool Status(int ID);

        List<T> GetAll();

        T GetByID(int ID);

        List<T> GetAllLambda(Expression<Func<T, bool>> lambda);
    }
}
