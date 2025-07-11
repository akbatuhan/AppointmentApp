using DataAccesLayer.Abstract;
using DataAccesLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repository
{
    public class GenericRepository<T> : IGeneric<T> where T : class, new()
    {
        
        public void Delete(T item)
        {
            using var c = new Contextt();
            c.Remove(item);
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var c=new Contextt();
            return c.Set<T>().ToList();
        }

        public T GetbyId(int id)
        {
            using var c=new Contextt();
            return c.Set<T>().Find(id);

        }

        public void Insert(T item)
        {
            using var c=new Contextt();
            c.Add(item);
            c.SaveChanges();

        }

        public void Update(T item)
        {
            using var c=new Contextt();
            c.Update(item);
            c.SaveChanges();
        }
    }
}
