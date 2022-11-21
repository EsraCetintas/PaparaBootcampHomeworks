using GenericRepositoryDemo.Data.Abstract;
using GenericRepositoryDemo.Data.Context;
using GenericRepositoryDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Data.Concrete.EntityFramework
{
    public class RepositoryBase<T,TContext> : IRepository<T> 
        where T : BaseEntity
        where TContext : DbContext,new()
    {
        readonly TContext _context;

        public RepositoryBase(TContext context)
        {
            this._context = context;
        }

        //This method makes a insertion to the database
        public void Add(T entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        //This method brings a data from the database
        public T Get(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().SingleOrDefault(p => p.Id == id);
            }
        }

        //This method fetches data from the database
        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
                return filter == null ? _context.Set<T>().ToList()
                                 : _context.Set<T>().Where(filter).ToList();

        }

        //This method makes a deletion from the database
        public void Delete(T entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }   
        }

        //This method updates to the database
        public void Update(T entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
                
        }
    }
}
