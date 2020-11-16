using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Machine.Core.Entities
{
    public class Sugar : ITaste
    {
        [Range(10, 70, ErrorMessage = "Value must be from 10 to 70")]
        public int Quantity { get; set; }     
       
        public void Add(OrderDetails OrderDtl)
        {
            OrderDtl.SugarQuantity = Quantity;
        }
    }
}
