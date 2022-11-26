using GenericRepositoryDemo.Core.Caching;
using GenericRepositoryDemo.Data.Abstract;
using GenericRepositoryDemo.Data.Context;
using GenericRepositoryDemo.Domain.Entities;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Data.Concrete.EntityFramework
{
    public class RepositoryBase<T> : IRepository<T> 
        where T : BaseEntity
    {
        public AppDbContext Context { get; }

        public RepositoryBase(AppDbContext context)
        {
            Context = context;
        }

        //This method makes a insertion to the database
        public async Task Add(T entity)
        {
           await Context.Set<T>().AddAsync(entity);
           await Context.SaveChangesAsync();
        }

        //This method brings a data from the database
        public async Task<T> Get(int id)
        {
            var result =await Context.Set<T>().SingleOrDefaultAsync(p=>p.Id==id);
            if (result is null)
                throw new Exception();

            return result;
        }

        //This method fetches data from the database
        public async Task<List<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
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
            throw new Exception();
        }

        //This method updates to the database
        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}