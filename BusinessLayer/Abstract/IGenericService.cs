using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class, new()
    {
        public void Insert(T item);
        public void Delete(T item);
        public void Update(T item);
        public List<T> GetAll();
        public T GetbyId(int id);

    }
}
