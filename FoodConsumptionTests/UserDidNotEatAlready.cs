using System;
using FoodConsumption.Models;
using FoodConsumption.Repositories;
using TestStack.BDDfy;
using Xunit;

namespace FoodConsumptionTests
{
    public class UserDidNotEatAlready
    {
        private ICaloriesRepository caloriesRepository;
        private const int userId = 42;

        public UserDidNotEatAlready()
        {
            this.caloriesRepository = new CaloriesRepository();
        }

        public void GivenTheFactIDidNotEatToday()
        {
            
        }

        public void WhenIEatPancakes()
        {
            this.caloriesRepository.Eat(new EatingAction(userId, AvailableFood.Pancakes));
        }

        public void ThenIShouldHaveEaten520Calories()
        {
            var caloriesForUser = this.caloriesRepository.GetCalories(userId);
            Assert.Equal(520, caloriesForUser);
        }

        [Fact]
        public void UserShouldHaveTheirCaloriesCalculatedProperlyWhenTheyDidNotEatBeforeEatingAgain()
        {
            this.BDDfy();
        }
    }
}
