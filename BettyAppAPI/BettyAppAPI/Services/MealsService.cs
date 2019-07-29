using AutoMapper;
using BettyAppAPI.Dtos;
using BettyAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettyAppAPI.Services
{
    public class MealsService
    {
        DatabaseContext database;
        private IMapper mapper;

        public MealsService(DatabaseContext _database, IMapper _mapper)
        {
            database = _database;
            mapper = _mapper;
        }
        //Return all meals associated with a specified dietitian

        //Return all Meal plans associated with a specidied dietitian

        //Return all Meal sets associated with a particular dietitian

        //Return all Meals Plans within a specified cost range

        //Add meals
        public void addMeal(MealDto mealDto)
        {
            Meal meal = mapper.Map<Meal>(mealDto);
            int meal_id, ingredient_id, step_id;

            database.Meals.Add(meal);
            database.SaveChanges();

            meal_id = meal.id;
            Console.WriteLine("This is the id: " + meal.id);
        }
            //save meal --> save ingredients --> save perp steps
            

        //Add meal sets

        //Add eating plans

        //Update meals

        //Update meal sets

        //Update eating plans

        //Delete meals

        //Delete meal sets

        //Delete eating plans
    }
}
