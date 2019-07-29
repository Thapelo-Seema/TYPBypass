using BettyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Dtos
{
    public class MealSetDto
    {
        int id { get; set; }

        string label { get; set; }

        Meal breakfast { get; set; }

        Meal lunch { get; set; }

        Meal supper { get; set; }

        Meal snack { get; set; }

        double cost { get; set; }
    }
}
