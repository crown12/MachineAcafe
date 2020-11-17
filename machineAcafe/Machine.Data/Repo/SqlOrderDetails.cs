using Machine.Core.Entities;
using Machine.Data.ApplicationEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Data.Repo
{
    public class SqlOrderDetails : IOrderDetail
    {
        private readonly IOrder order;
        private readonly AppDbContext context;

        public SqlOrderDetails(IOrder order, AppDbContext context)
        {
            this.order = order;
            this.context = context;
        }
        public async Task Add(OrderDetails orderDtl, int id)
        {
            orderDtl.Order = await order.GetOrderByBadgeId(id);
            await context.AddAsync(orderDtl);
            await Commit();
        }

        public async Task<int> Commit()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            return await context.orderDetails.Include(o => o.Drink)
                                             .Include(o => o.Order)
                                             .FirstOrDefaultAsync(od => od.Order.Id == id);
                 
        }
    }
}
