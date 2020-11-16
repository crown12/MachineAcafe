using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Machine.Core.Entities;
using Machine.Data.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

//using Newtonsoft.Json;

namespace machineAcafe.Pages.AvailableDrinks
{
    public class ServeDrinkModel : PageModel
    {
        private readonly IDrink drinks;
        private readonly IBadge badge;
        private readonly IOrder order;

        public ServeDrinkModel(IDrink drinks, IBadge badge, IOrder order)
        {
            this.drinks = drinks;
            this.badge = badge;
            this.order = order;
        }

        public List<Drink> Drinks{ get; set; }
        
        [BindProperty]
        public Order Order { get; set; }

        [BindProperty]
        public Badge Badge { get; set; }

        [BindProperty]
        public Drink Drink { get; set; }

        [BindProperty]
        public OrderDetails OrderDtl{ get; set; }

        [BindProperty]
        public int Sugar { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string BadgeId { get; set; }

        public void OnGet()
        {
            
            Drinks = drinks.GetAllDrinks().ToList();

        }

        public IActionResult OnPost()
        {                        
            if (ModelState.IsValid )
            {
                if (badge.Find(Badge.Serial) != null)
                {
                    
                   //var errors = ModelState.Values.SelectMany(v => v.Errors);
                    OrderDtl.Drink = drinks.GetDrinkById(Drink.Id);
                    Order.Badge = badge.Find(Badge.Serial);
                    

                    var sugar = new Sugar(Sugar);
                    sugar.Add(OrderDtl);

                    order.AddOrder(Order);
                }
                else
                {
                    return RedirectToPage("./Thanks");
                }
           
            
            }
            else
            {
                Drinks =  drinks.GetAllDrinks().ToList();
                return Page();
            }
           
            return RedirectToPage("./Thanks");
        }
    }
}
