using Machine.Core.Entities;
using Machine.Data.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace machineAcafe.ViewModels
{
    public class DrinkOrder
    {
        public DrinkOrder()
        {
            Quantity = 0;
        }
        public string BadgeSerial{ get; set; }
        public int DrinkId { get; set; }

        [Range(10, 70, ErrorMessage = "Value must be from 10 to 70")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please select an option.")]
        public bool Mug { get; set; }

        
    }
}
