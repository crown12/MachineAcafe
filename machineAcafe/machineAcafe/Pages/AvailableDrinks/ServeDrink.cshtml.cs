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

        public void OnGet()
        {
            Drinks = drinks.GetAllDrinks().ToList();
            
        }

        public IActionResult OnPost()
        {
            var badgeExists = new Badge();

            if (Order.Badge.Serial!=null)
            {  
               badgeExists=  badge.Find(Order.Badge.Serial); 
            }
            
            var quantity = Order.Drink.Sugar;

            if(badgeExists!= null)
            {
                Order.Badge = badgeExists;
                
                var drink = drinks.GetDrinkById(Order.Drink.Id);
                var sugar = new Sugar(Order.Drink.Sugar);
                
                sugar.Add(drink);

                
                Order.Drink = drink;
                order.AddOrder(Order);
            }
            var myOrders = order.GetAllOrders();

            return RedirectToPage("../Index");
        }
    }
}
