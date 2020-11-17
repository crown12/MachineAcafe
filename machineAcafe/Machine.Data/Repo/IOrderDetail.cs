using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Data.Repo
{
    public interface IOrderDetail
    {
        Task Add(OrderDetails orderDtl, int id);
        Task<OrderDetails> GetOrderDetailsByOrderId(int id);
        Task<int> Commit();
    }
}
