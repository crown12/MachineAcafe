using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Machine.Core.Entities
{
    public class Drink
    {
        [Key]      
        public int Id { get; set; }

        
        public string Name { get; set; }        
        
        [Range(10,70, ErrorMessage = "Value must be from 10 to 70")]        
        public int Sugar { get; set; }
    }

}
