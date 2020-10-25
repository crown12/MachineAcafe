using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine.Data.Repo
{
    public class InMemoryDrinks : IDrink
    {
        public IEnumerable<Drink> GetAllDrinks()
        {
            var drinks = new List<Drink>
            {
                new Drink{Id=1,Name="Cafe"},
                new Drink{Id=2,Name="The"},
                new Drink{Id=3,Name="Chocolat"}
            };
            return drinks;
        }
    }
}
