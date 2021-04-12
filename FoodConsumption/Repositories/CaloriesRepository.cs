using System;
using System.Collections.Concurrent;
using System.Linq;
using FoodConsumption.Models;

namespace FoodConsumption.Repositories
{
    public class CaloriesRepository : ICaloriesRepository
    {
        private ConcurrentBag<EatingAction> foodBag = new ConcurrentBag<EatingAction>();

        public CaloriesRepository()
        {
        }

        public void Eat(EatingAction eatingAction) => foodBag.Add(eatingAction);

        public int GetCalories(int userId)
        {
            var eatenFood = this.foodBag.Where(f => f.UserId == userId).Select(f => f.Food);
            var totalCalories = 0;

            foreach (var food in eatenFood)
            {
                var currentCalories = GetCaloriesForFood(food);
                totalCalories += currentCalories;
            }
            return totalCalories;
        }

        private int GetCaloriesForFood(AvailableFood food) => food switch
        {
            AvailableFood.Pancakes => 520,
            AvailableFood.Burger => 550,
            AvailableFood.CaesarSalad => 180,
            _ => throw new ArgumentOutOfRangeException(nameof(food)),
        };
    }
}
