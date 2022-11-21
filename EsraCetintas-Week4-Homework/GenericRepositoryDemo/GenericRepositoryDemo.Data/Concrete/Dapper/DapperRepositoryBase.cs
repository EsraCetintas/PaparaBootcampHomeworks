using Dapper;
using GenericRepositoryDemo.Data.Abstract;
using GenericRepositoryDemo.Data.Context;
using GenericRepositoryDemo.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Data.Concrete.Dapper
{
    public class DapperRepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        private readonly string _tableName;
        private readonly DapperDbContext _context;

        public DapperRepositoryBase(string tableName, DapperDbContext context)
        {
            _tableName = tableName;
            _context = context;
        }

        //This method takes the property names
        private IEnumerable<string> GetColumnNames()
        {
            return typeof(T)
                   .GetProperties()
                   .Where(p => p.Name != "Id"
                   && !p.PropertyType.GetTypeInfo().IsGenericType)
                   .Select(p => p.Name);
        }

        //This method makes a insertion to the database
        public void Add(T entity)
        {
            using(var connection = _context.CreateConnection())
            {
                var columns = GetColumnNames();
                var stringOfColumns = string.Join(", ", columns);
                var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
                var query = $"insert into {_tableName} ({stringOfColumns}) values ({stringOfParameters})";
                connection.Execute(query,entity);
            }
        }

        //This method makes a deletion from the database
        public void Delete(T entity)
        {
            using (var connection = _context.CreateConnection())
            {
                connection.Execute($"DELETE FROM {_tableName} WHERE Id=@Id", new { Id = entity.Id });
            }
        }

        //This method brings a data from the database
        public T Get(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var result = connection.QuerySingleOrDefault<T>($"SELECT * FROM {_tableName} WHERE Id=@Id", new { Id = id });
                return result;
            }
        }

        //This method fetches data from the database
        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var connection = _context.CreateConnection())
            {
               return connection.Query<T>($"SELECT * FROM {_tableName}").AsQueryable().ToList();
            }
        }

        //This method updates to the database
        public void Update(T entity)
        {
            using (var connection = _context.CreateConnection())
            {
                var columns = GetColumnNames();
                var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
                var query = $"update {_tableName} set {stringOfColumns} where Id = @Id";
                connection.Execute(query, entity);
            }
        }
    }
}
