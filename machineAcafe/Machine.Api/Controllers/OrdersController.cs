using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Machine.Core.Entities;
using Machine.Data.Repo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Machine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrder orders;

        public OrdersController(IOrder order)
        {
            this.orders = order;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Order> GetAllOrders ()
        {
            return orders.GetAllOrders();
        }

        // GET api/<OrdersController>/5
       [HttpGet("{serial}")]
        public Order GetOrderByBadgeSerial(string serial)
        {
            return orders.GetOrderByBadgeSerial(serial);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            order.Id = 0;
            orders.AddOrder(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
