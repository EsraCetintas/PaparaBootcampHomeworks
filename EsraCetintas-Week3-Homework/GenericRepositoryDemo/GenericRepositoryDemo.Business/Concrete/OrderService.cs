using GenericRepositoryDemo.Business.Abstract;
using GenericRepositoryDemo.Data.Abstract;
using GenericRepositoryDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Business.Concrete
{
    public class OrderService : IOrderService
    {
        readonly IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        //This method makes a insertion
        public void Add(Order order)
        {
            _repository.Add(order);
        }

        //This method makes a deletion 
        public void Delete(Order order)
        {
            _repository.Delete(order);
        }

        //This method fetches data 
        public IEnumerable<Order> GetAll()
        {
            return _repository.GetAll();
        }

        //This method fetches a data 
        public Order GetById(int id)
        {
            return _repository.Get(p => p.Id == id);
        }

        //This method updates
        public void Update(Order order)
        {
            _repository.Update(order);
        }
    }
}
