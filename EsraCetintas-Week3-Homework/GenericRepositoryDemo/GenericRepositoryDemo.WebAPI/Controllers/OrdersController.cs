using GenericRepositoryDemo.Business.Abstract;
using GenericRepositoryDemo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GenericRepositoryDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //This method makes a insertion
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Add(Order order)
        {
           _orderService.Add(order);
            return Ok();
        }

        //This method brings a data
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _orderService.GetById(id);
            return Ok(result);
        }

        //This method fecthes data
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            return Ok(result);
        }

        //This method makes a deletion
        [HttpDelete]
        [Consumes("application/json")]
        public IActionResult Delete(Order order)
        {
            _orderService.Delete(order);
            return Ok();
        }

        //This method updates a data
        [HttpPut]
        [Consumes("application/json")]
        public IActionResult Update(Order order)
        {
            _orderService.Update(order);
            return Ok();
        }
    }
}

