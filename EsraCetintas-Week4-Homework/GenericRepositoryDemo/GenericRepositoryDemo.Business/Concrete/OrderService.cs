using AutoMapper;
using GenericRepositoryDemo.Business.Abstract;
using GenericRepositoryDemo.Business.DTO_s;
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
        readonly IMapper _mapper;

        readonly IOrderDal _orderDal;

        public OrderService(IOrderDal orderDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _mapper = mapper;
        }

        //This method makes a insertion
        public void Add(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.CreatedDate = DateTime.Now;
            order.CreatedBy = "System";
            order.IsDeleted = false;
            _orderDal.Add(order);
        }

        //This method makes a deletion 
        public void Delete(int id)
        {
            var order = CheckOrder(id);
            _orderDal.Delete(order);
        }

        //This method fetches data 
        public IEnumerable<OrderDto> GetAll()
        {
            List<OrderDto> orders =new List<OrderDto>();

            foreach (var item in _orderDal.GetAll())
            {
                var order = _mapper.Map<OrderDto>(item);
                orders.Add(order);
            }
            return  orders;
        }

        //This method fetches a data 
        public OrderDto GetById(int id)
        {
            var orderChecked = CheckOrder(id);
            var order = _mapper.Map<OrderDto>(orderChecked);
            return order;
        }

        //This method updates
        public void Update(int id, OrderDto orderDto)
        {
            var order = CheckOrder(id);

            var orderToUpdate = _mapper.Map<Order>(orderDto);
            orderToUpdate.Id = order.Id;
            orderToUpdate.LastUpdatAt = DateTime.Now;
            orderToUpdate.CreatedBy = "System";
            orderToUpdate.IsDeleted = false;
            orderToUpdate.CreatedDate = order.CreatedDate;
            _orderDal.Update(orderToUpdate);
        }

        private Order CheckOrder(int id)
        {
            var order = _orderDal.Get(id);
            if (order != null)
            {
                return order;
            }

            throw new Exception("Not Found");
        }
    }
}
