using GenericRepositoryDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Business.Abstract
{
    public interface IOrderService
    {
        Order GetById(int id);
        IEnumerable<Order> GetAll();
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}
