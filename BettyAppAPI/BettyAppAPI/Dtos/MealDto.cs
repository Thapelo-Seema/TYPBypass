using BettyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Dtos
{
    public class MealDto
    {
        public int id { get; set; }

        public string dietitian_id { get; set; }

        public string meal_type { get; set; }

        public string description { get; set; }

        public int serving_size { get; set; }

        public int preparation_time { get; set; }

        public double meal_cost { get; set; }

        public List<Ingredient> ingredients { get; set; }

        public List<PreparationStep> preparationSteps { get; set; }

        public Boolean isComplete { get; set; }
    }
}
