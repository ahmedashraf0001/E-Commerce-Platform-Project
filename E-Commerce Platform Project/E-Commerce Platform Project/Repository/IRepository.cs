using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Platform_Project.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> All();
        T GetByID(int id);

        T Add(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
