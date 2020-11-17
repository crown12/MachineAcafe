using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Data.Repo
{
    public interface IOrder
    {
        Task<Order> GetLastOrder();
        Task AddOrder(Order order);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderByBadgeId(int? badgeId);
        Task<Order> GetOrderByBadgeSerial(string serial);
        Task<int> Commit();
    }
}
