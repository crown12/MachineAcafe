using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Machine.Core.Entities;
using Machine.Data.Repo;
using machineAcafe.ViewModels;
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
        private readonly IOrderDetail orderDetail;

        public ServeDrinkModel(IDrink drinks, IBadge badge, IOrder order, IOrderDetail orderDetail)
        {
            this.drinks = drinks;
            this.badge = badge;
            this.order = order;
            this.orderDetail = orderDetail;
        }

        public List<Drink> Drinks{ get; set; }      

        [BindProperty(SupportsGet =true)]
        public DrinkOrder drinkOrder { get; set; }


        public void OnGet()
        {            
            Drinks = drinks.GetAllDrinks().ToList();            
            drinkOrder.Quantity = 6;            
        }

        public IActionResult OnPost()
        {
          
            if (!ModelState.IsValid )
            {   // var errors = ModelState.Values.SelectMany(v => v.Errors);
                Drinks = drinks.GetAllDrinks().ToList();             
                return Page();   
            }

            if (badge.Find(drinkOrder.BadgeSerial) != null)
            {
                var Order = new Order();
                var OrderDtl = new OrderDetails();
                var sugar = new Sugar(drinkOrder.Quantity);

                Order.Badge = badge.Find(drinkOrder.BadgeSerial);
                order.AddOrder(Order);

                OrderDtl.Drink = drinks.GetDrinkById(drinkOrder.DrinkId);
                OrderDtl.Mug = drinkOrder.Mug;
                sugar.Add(OrderDtl);

                var result = orderDetail.Add(OrderDtl, Order.Badge.Id);

            }
           
            return RedirectToPage("./Thanks");
        }
    }
}
