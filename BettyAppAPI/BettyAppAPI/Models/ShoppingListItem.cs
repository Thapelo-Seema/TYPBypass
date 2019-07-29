using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Models
{
    public class ShoppingListItem : Ingredient
    {
        string productBrand { get; set; }
        string productSupplier { get; set; }
    }
}
