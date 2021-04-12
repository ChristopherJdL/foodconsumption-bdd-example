using System;
namespace FoodConsumption.Models
{
    public class EatingAction
    {
        public EatingAction(int userId, AvailableFood food)
        {
            UserId = userId;
            Food = food;
        }

        public int UserId { get; set; }
        public AvailableFood Food { get; set; }
    }

    public enum AvailableFood
    {
        Pancakes,
        CaesarSalad,
        Burger
    }
}
