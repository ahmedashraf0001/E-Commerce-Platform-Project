using E_Commerce_Platform_Project.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Platform_Project.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        EcommerceContextDB context;
        DbSet<T> set;
        public Repository(EcommerceContextDB _cntx) 
        {
            context = _cntx ?? throw new ArgumentNullException(nameof(context));
            set = context.Set<T>(); 
        }
        public T Add(T entity)
        {
            try 
            {
                set.Add(entity);
                context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error adding entity", ex);
            }
        }

        public List<T> All()
        {
            return set.ToList();
        }

        public void Delete(int id)
        {
            try 
            {
                var res = GetByID(id);
                if (res != null)
                {
                    set.Remove(res);
                    context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException($"Entity with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error deleting entity", ex);
            }
        }

        public T GetByID(int id)
        {
            return set.Find(id);
        }

        public void Update(T entity)
        {
            try
            {
                set.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error updating entity", ex);
            }
        }
    }
}
