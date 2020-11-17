using Machine.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine.Data.ApplicationEF
{
    public partial class AppDbContext : DbContext
    {
        public static OptionBuild ops = new OptionBuild();
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<Drink> drinks { get; set; }
        public DbSet<Badge> badges { get; set; }
        public DbSet<Order> orders{ get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }



    }
}
