using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Models.ViewModels
{
    public class FoodNutrientVM
    {
        public int Id { get; set; }
        public string NutrientName { get; set; }
        public string UnitName { get; set; }
        public string Value { get; set; }
    }
}
