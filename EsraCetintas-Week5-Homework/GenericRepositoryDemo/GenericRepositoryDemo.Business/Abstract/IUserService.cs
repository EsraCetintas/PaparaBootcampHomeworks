using GenericRepositoryDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Business.Abstract
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task Add(User user);
    }
}
