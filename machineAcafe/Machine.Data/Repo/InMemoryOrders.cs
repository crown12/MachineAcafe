using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Machine.Data.Repo
{
    public class InMemoryOrders : IOrder
    {
        private readonly IBadge _badge;
        private readonly IDrink _drink;
        List<Order> orders = new List<Order>();
        public InMemoryOrders(IBadge badge, IDrink drink)
        {           
            this._badge = badge;
            this._drink = drink;

            orders = new List<Order> { 
                new Order{Id=1,Badge=_badge.Find("1234"), OrderDate= DateTime.Now.AddDays(-2) } ,
                new Order{Id=2,Badge=_badge.Find("5678"),OrderDate= DateTime.Now.AddDays(-1)}
            };
            
        }
       
        public Order AddOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            order.Id = orders.OrderByDescending(o => o.Id).First().Id + 1 ;
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
            return orders.OrderByDescending(o => o.OrderDate).Take(1).Single();
        }

        public Order GetOrderByBadgeSerial(string serial)
        {
            //return orders.SingleOrDefault(b => b.Badge.Serial.StartsWith(serial));
            var query = from o in orders
                        orderby o.OrderDate descending
                        where o.Badge.Serial.Equals(serial)
                        select o;
            if (query.Count() <= 0 || serial == null)
                return null;
            else
               return query.Single(); 
        }
    }
}
