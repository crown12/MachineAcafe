using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.Data.Repo
{
    public class InMemoryOrders : IOrder
    {
        
        List<Order> orders = new List<Order>();
       
        public Order AddOrder(Order order)
        {
            

            order.OrderDate = DateTime.Now;

           
            orders.Add(order);
            return order;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return orders.ToList();
        }

        public Order GetLastOrder()
        {         
            return orders.OrderByDescending(o => o.OrderDate).Take(1).Single();                
        }

        public Order GetOrderByBadgeId(int? badgeId)
        {
            return orders.Find(o => o.Badge.Id == badgeId);
        }
    }
}
