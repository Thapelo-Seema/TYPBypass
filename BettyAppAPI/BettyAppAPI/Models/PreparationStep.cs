using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Models
{
    public class PreparationStep
    {
        [Key]
        public int id { get; set; }
        public int meal_id { get; set; }
        public string label { get; set; }
        public string details { get; set; }
    }
}
