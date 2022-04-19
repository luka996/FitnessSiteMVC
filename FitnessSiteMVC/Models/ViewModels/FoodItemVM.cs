using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Models.ViewModels
{
    public class FoodItemVM
    {
        public FoodItemVM()
        {
            FoodNutrients = new List<FoodNutrientVM>();
        }

        public int Id { get; set; }

        public string LowerDescription { get; set; }
        public string BrandName { get; set; }
        public List<FoodNutrientVM> FoodNutrients { get; set; }
        public string Amount { get; set; }
        public string EntryId { get; set; }
    }
}
