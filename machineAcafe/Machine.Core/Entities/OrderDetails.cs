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
                
        public Order Order { get; set; }
        
        public Drink Drink { get; set; }
       
        public int SugarQuantity { get; set; }
        
        [Required(ErrorMessage ="Please select an option.")]
        public bool Mug { get; set; }
    }
}
