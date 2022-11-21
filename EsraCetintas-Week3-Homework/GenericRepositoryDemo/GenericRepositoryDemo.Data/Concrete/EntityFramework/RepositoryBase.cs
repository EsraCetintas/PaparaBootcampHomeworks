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
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        public AppDbContext Context { get; }
        public RepositoryBase(AppDbContext context)
        {
            Context = context;
        }

        //This method makes a insertion to the database
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        //This method brings a data from the database
        public T Get(Expression<Func<T, bool>> filter)
        {
            return Context.Set<T>().SingleOrDefault(filter);
        }

        //This method fetches data from the database
        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return filter == null ? Context.Set<T>().AsQueryable()
                                  : Context.Set<T>().Where(filter).AsQueryable();
        }

        //This method makes a deletion from the database
        public void Delete(T entity)
        {
            var deletedEntity = Context.Set<T>().SingleOrDefault(p => p.Id == entity.Id);
            if (deletedEntity != null)
            {
                Context.Set<T>().Remove(deletedEntity);
                Context.SaveChanges();
            }
        }

        //This method updates to the database
        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
