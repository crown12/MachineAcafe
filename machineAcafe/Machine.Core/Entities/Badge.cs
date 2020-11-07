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
        
        [Required(ErrorMessage = "Name length can't be more than 8.")]
        public bool Mug { get; set; }

    }
}
