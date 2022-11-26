using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Data.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();

        //List<T> GetAll();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
