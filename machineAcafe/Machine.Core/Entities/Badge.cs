using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Machine.Core.Entities
{
    public class Badge
    {
        [Key]
        public int Id { get; set; }
        public string Serial { get; set; }
        public string Name { get; set; }      
       
    }
}
