using GenericRepositoryDemo.Business.DTO_s;
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
        OrderDto GetById(int id);
        IEnumerable<OrderDto> GetAll();
        void Add(OrderDto orderDto);
        void Update(int id, OrderDto orderDto);
        void Delete(int id);
    }
}
