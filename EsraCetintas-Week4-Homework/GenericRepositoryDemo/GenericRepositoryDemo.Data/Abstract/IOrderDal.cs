using GenericRepositoryDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Data.Abstract
{
   public interface IOrderDal : IRepository<Order>
    {
    }
}
