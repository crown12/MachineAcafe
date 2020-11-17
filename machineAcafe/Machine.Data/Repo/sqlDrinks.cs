using Machine.Core.Entities;
using Machine.Data.ApplicationEF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Machine.Data.Repo
{
    public class SqlDrinks : IDrink
    {
        private readonly AppDbContext context;

        public SqlDrinks(AppDbContext  context)
        {
            this.context = context;
        }
        public async Task<List<Drink>> GetAllDrinks()
        {
            return await context.drinks.ToListAsync();
        }

        public async Task<Drink> GetDrinkById(int id)
        {
            return await context.drinks.SingleOrDefaultAsync(d => d.Id == id);
        }
    }
}
