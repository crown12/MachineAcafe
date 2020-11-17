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
        public async Task<IEnumerable<Order>> GetAllOrders ()
        {
            return await orders.GetAllOrders();
        }

        // GET api/<OrdersController>/5
       [HttpGet("{serial}")]
        public async Task<Order> GetOrderByBadgeSerial(string serial)
        {
            return await orders.GetOrderByBadgeSerial(serial);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task Post([FromBody] Order order)
        {
            
            await orders.AddOrder(order);
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
