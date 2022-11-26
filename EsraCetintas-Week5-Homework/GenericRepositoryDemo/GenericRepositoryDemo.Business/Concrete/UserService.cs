using GenericRepositoryDemo.Business.Abstract;
using GenericRepositoryDemo.Core.Caching;
using GenericRepositoryDemo.Data.Abstract;
using GenericRepositoryDemo.Domain.Entities;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Business.Concrete
{
    public class UserService : IUserService
    {
        string _cacheKey = $"{typeof(UserService)}";
        readonly IRepository<User> _repository;
        readonly ICacheService _cacheService;

        public UserService(IRepository<User> repository, ICacheService cacheService)
        {
            _repository = repository;
            _cacheService = cacheService;
        }
        
        //This method adds an insertion to the database

        public async Task Add(User user)
        {
            await _repository.Add(user);
            BackgroundJob.Enqueue(() => ProcessRecurringJobCaching());
        }

        //This method firstly checks the cache if the cache is empty, the method adds data to the cache.
        //or if the cache is full, the method fetches data from the cache.
        public async Task<List<User>> GetAll()
        {
            var result = _cacheService.TryGet<List<User>>(_cacheKey, out List<User> value);
            if (!result)
            {
                 var list = await _repository.GetAll();
                _cacheService.Add<List<User>>(_cacheKey, list);
                return list;
            }
            return value;
        }

        //This method firstly cleans the cache then adds to the cache.
        public void ProcessRecurringJobCaching()
        {
            _cacheService.Remove(_cacheKey);
            var list = _repository.GetAll();
            _cacheService.Add(_cacheKey, list);
        }
    }
}
