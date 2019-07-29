using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettyAppAPI.Dtos;
using BettyAppAPI.Models;
using BettyAppAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BettyAppAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class MealsController : Controller
    {
        private DatabaseContext database;
        private MealsService mealsService;

        public MealsController(DatabaseContext _database, MealsService _mealsService)
        {
            database = _database;
            mealsService = _mealsService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]MealDto mealDto)
        {
            mealsService.addMeal(mealDto);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
