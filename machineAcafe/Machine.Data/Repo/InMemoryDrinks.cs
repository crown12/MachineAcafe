using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;

namespace Machine.Data.Repo
{
    public class InMemoryDrinks : IDrink
    {
        List<Drink> Drinks { get; set; }
        public InMemoryDrinks()
        {
            Drinks = new List<Drink>
            {
                new Drink{Id=1,Name="Coffee",Sugar=20},
                new Drink{Id=2,Name="Tea"},
                new Drink{Id=3,Name="Chocolat"}
            };
        }
        public IEnumerable<Drink> GetAllDrinks()
        {
            return from d in Drinks
                   orderby d.Id 
                   select d;
        }

        public Drink GetDrinkById(int id)
        {
            return Drinks.SingleOrDefault(d => d.Id == id);
        }
    }
}
