using System;
using System.Collections.Generic;
using System.Text;

namespace Machine.Core.Entities
{
    public class Sugar : ITaste
    {
        private int quantity { get; set; }
        public Sugar(int quantity)
        {
            this.quantity = quantity;
        }

        public void Add(Drink drink)
        {
            drink.Sugar = quantity;
        }
    }
}
