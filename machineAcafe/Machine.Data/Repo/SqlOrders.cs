using Machine.Core.Entities;
using Machine.Data.ApplicationEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Data.Repo
{
    public class SqlOrders : IOrder
    {

        private readonly AppDbContext context;

        public SqlOrders(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            await context.orders.AddAsync(order);
            await Commit();

        }

        public async Task<int> Commit()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await context.orders.Include(o => o.Badge).ToListAsync();
        }

        public async Task<Order> GetLastOrder()
        {
            return await context.orders.OrderByDescending(o => o.OrderDate).FirstAsync();
        }

        public async Task<Order> GetOrderByBadgeId(int? badgeId)
        {
            return await context.orders.Include(o => o.Badge)
                                       .OrderByDescending(o => o.OrderDate)
                                       .FirstOrDefaultAsync(o => o.Badge.Id == badgeId);
        }

        public async Task<Order> GetOrderByBadgeSerial(string serial)
        {            
            return await context.orders.Include(o => o.Badge)
                                       .OrderByDescending(o => o.OrderDate)
                                       .Where(o => o.Badge.Serial == serial)
                                       .FirstAsync(); 
                
        }
    }
}
