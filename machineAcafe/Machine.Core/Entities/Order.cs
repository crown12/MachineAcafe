using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Machine.Core.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Badge Badge { get; set; }
        
        public DateTime OrderDate { get; set; }
        

    }
}
