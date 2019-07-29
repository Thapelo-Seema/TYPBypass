using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Models
{
    public class Meal
    {
        [Key]
        public int id { get; set; }

        public string dietitian_id { get; set; }

        public string meal_type { get; set; }

        public string description { get; set; }

        public int serving_size { get; set; }

        public int preparation_time { get; set; }

        public double meal_cost { get; set; }


        public Boolean isComplete { get; set; }


      
    }
}
