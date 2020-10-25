using Machine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Machine.Data.Repo
{
    public interface IDrink
    {
        IEnumerable<Drink> GetAllDrinks();

    }
}
