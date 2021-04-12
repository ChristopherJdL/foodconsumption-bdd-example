using System;
using FoodConsumption.Models;
using FoodConsumption.Repositories;
using TestStack.BDDfy;
using Xunit;

namespace FoodConsumptionTests
{
    public class UserAteAlready
    {
        private ICaloriesRepository caloriesRepository;
        private const int userId = 42;

        public UserAteAlready()
        {
            this.caloriesRepository = new CaloriesRepository();
        }

        public void GivenTheFactThatIAlreadyAteABurger()
        {
            this.caloriesRepository.Eat(new EatingAction(userId, AvailableFood.Burger));
        }

        public void WhenIEatACaesarSalad()
        {
            this.caloriesRepository.Eat(new EatingAction(userId, AvailableFood.CaesarSalad));
        }

        public void ThenIShouldHaveEaten730Calories()
        {
            var caloriesForUser = this.caloriesRepository.GetCalories(userId);
            Assert.Equal(730, caloriesForUser);
        }

        [Fact]
        public void UserShouldHaveTheirCaloriesCalculatedProperlyWhenTheyAteAlreadyBeforeEatingAgain()
        {
            this.BDDfy();
        }
    }
}
