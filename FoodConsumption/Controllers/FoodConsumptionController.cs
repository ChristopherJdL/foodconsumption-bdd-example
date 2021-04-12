using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodConsumption.Models;
using FoodConsumption.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodConsumption.Controllers
{
    [Route("[controller]")]
    public class FoodConsumptionController : Controller
    {
        private readonly ICaloriesRepository caloriesRepository;

        public FoodConsumptionController(ICaloriesRepository caloriesRepository)
        {
            this.caloriesRepository = caloriesRepository;
        }

        [HttpPost]
        public void Eat(EatingAction action) => caloriesRepository.Eat(action);
    }
}
