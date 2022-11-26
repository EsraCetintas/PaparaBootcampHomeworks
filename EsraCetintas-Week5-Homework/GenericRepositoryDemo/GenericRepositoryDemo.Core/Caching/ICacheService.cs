using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Core.Caching
{
    public interface ICacheService
    {
        bool TryGet<T>(string cacheKey, out T value);
        T Add<T>(string cacheKey, T value);
        void Remove(string cacheKey);
    }
}
