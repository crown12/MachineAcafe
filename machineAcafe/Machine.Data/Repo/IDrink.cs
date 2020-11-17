using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Data.Repo
{
    public interface IDrink
    {
        Task<List<Drink>> GetAllDrinks();
        Task<Drink> GetDrinkById(int id);

    }
}
