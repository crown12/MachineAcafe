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
       
        public void  OnGet()
        {

            Drinks = GetDrinks();
        }

        public async Task<IActionResult> OnPost()
        {
          
            if (!ModelState.IsValid )
            {   // var errors = ModelState.Values.SelectMany(v => v.Errors);
                Drinks = await drinks.GetAllDrinks();             
                return Page();   
            }

            var badgeExists =await badge.Find(drinkOrder.BadgeSerial);
            if (badgeExists != null)
            {
                var Order = new Order();
                var OrderDtl = new OrderDetails();
                var sugar = new Sugar(drinkOrder.Quantity);

                Order.Badge = badgeExists;
                await order.AddOrder(Order);

                OrderDtl.Drink = await drinks.GetDrinkById(drinkOrder.DrinkId);
                OrderDtl.Mug = drinkOrder.Mug;
                sugar.Add(OrderDtl);

                await orderDetail.Add(OrderDtl, Order.Badge.Id);

            }
           
            return RedirectToPage("./Thanks");
        }


        public List<Drink> GetDrinks()
        {
            var url = "https://localhost:44387/api/drinks/";
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            string stringData = response.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<Drink>>(stringData, options);
        }
    }
}
