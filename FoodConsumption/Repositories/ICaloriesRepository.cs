using System;
using FoodConsumption.Models;

namespace FoodConsumption.Repositories
{
    public interface ICaloriesRepository
    {
        public int GetCalories(int userId);
        public void Eat(EatingAction eatingAction);
    }
}
