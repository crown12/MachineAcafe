using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Machine.Core.Entities
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Order Order { get; set; }

        [Required]
        public Drink Drink { get; set; }

        [Range(10, 70, ErrorMessage = "Value must be from 10 to 70")]
        public int SugarQuantity { get; set; }
                
        public bool Mug { get; set; }
    }
}
