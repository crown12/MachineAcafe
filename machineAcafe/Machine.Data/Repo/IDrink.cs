using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Machine.Data.Repo
{
    public interface IDrink
    {
        List<Drink> GetAllDrinks();
        Drink GetDrinkById(int id);

    }
}
