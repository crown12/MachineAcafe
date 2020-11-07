using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine.Data.Repo
{
    public interface IOrder
    {
        Order GetLastOrder();
        Order AddOrder(Order order);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderByBadgeId(int? badgeId);
    }
}
