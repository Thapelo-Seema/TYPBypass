using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Dtos
{
    public class IngredientDto
    {
        public string description { get; set; }

        public string foodCategory { get; set; }

        public string quantity_unit { get; set; }

        public string pictureUrl { get; set; }

        public double quantity { get; set; }

        public double cost { get; set; }
    }
}
