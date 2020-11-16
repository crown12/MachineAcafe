using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine.Data.Repo
{
    public class InMemoryOrderDetails : IOrderDetail
    {
        private readonly IOrder order;       
        private readonly IDrink drink;

        private List<OrderDetails> orderDetails;

        public InMemoryOrderDetails(IOrder order, IDrink drink)
        {
            orderDetails = new List<OrderDetails> {
            new OrderDetails{Id=1,Order=order.GetOrderByBadgeSerial("1234"),
                Drink=drink.GetDrinkById(1),
                SugarQuantity=20,Mug=false},
            new OrderDetails{Id=1,Order=order.GetOrderByBadgeSerial("5678"),
                Drink=drink.GetDrinkById(3),
                SugarQuantity=15,Mug=true}
            };
            this.drink = drink;
            this.order = order;
        }
    


        public OrderDetails Add(OrderDetails orderDtl,int id)
        {
            var LastOrder = order.GetOrderByBadgeId(id);
            orderDtl.Order = LastOrder;
             orderDetails.Add(orderDtl);
            return orderDtl;
            
        }
    }
}
