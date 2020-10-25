using System;
using System.Collections.Generic;
using System.Text;

namespace Machine.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        
        public Drink Drink{ get; set; }
        public int DrinkId { get; set; }

        public Badge Badge { get; set; }
        public int BadgeId { get; set; }

        public DateTime OrderDate { get; set; }

    }
}
