using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Machine.Core.Entities;
using Machine.Data.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace machineAcafe.Pages.AvailableDrinks
{
    public class ServeDrinkModel : PageModel
    {
        private readonly IDrink drinks;     

        public ServeDrinkModel(IDrink drinks)
        {
            this.drinks = drinks;            
        }

        public List<Drink> Drinks{ get; set; }
        
        public void OnGet()
        {
            Drinks = drinks.GetAllDrinks().ToList();            
        }
    }
}
