using BettyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Dtos
{
    public class MealPlanDto
    {
        int id { get; set; }

        string dietitian_id { get; set; }

        string dietitian_name { get; set; }

        string category { get; set; }

        string description { get; set; }

        string display_image { get; set; }

        double total { get; set; }

        int timestampCreated { get; set; }

        int timestampModified { get; set; }

        List<MealSet> mealPackages { get; set; }

        List<Meal> meals { get; set; }
    }
}
