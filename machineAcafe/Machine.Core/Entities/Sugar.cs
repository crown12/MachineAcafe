using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Machine.Core.Entities
{
    public class Sugar : ITaste
    {
        private int Quantity { get; set; }
        
        public Sugar(int quantity)
        {
            Quantity = quantity;
        }        
       
        public void Add(OrderDetails OrderDtl)
        {
            OrderDtl.SugarQuantity = Quantity;
        }
    }
}
