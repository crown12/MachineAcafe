using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine.Data.Repo
{
    public interface IOrderDetail
    {
        OrderDetails Add(OrderDetails orderDtl, int id);
        OrderDetails GetOrderDetailsByOrderId(int id);
    }
}
