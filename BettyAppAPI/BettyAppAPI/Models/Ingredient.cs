using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Models
{
    public class Ingredient
    {
        [Key]
        public int id { get; set; }
        public int meal_id { get; set; }

        public string description { get; set; }

        public string foodCategory { get; set; }

        public string quantity_unit { get; set; }

        public string pictureUrl { get; set; }

        public double quantity { get; set; }

        public double cost { get; set; }
    }
}
