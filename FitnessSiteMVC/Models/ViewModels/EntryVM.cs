using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Models.ViewModels
{
    public class EntryVM
    {
        public EntryVM()
        {
            FoodItems = new List<FoodItemVM>();
        }

        //public EntryVM(DateTime entryDate, int profileId)
        //{
        //   FoodItems = new List<FoodItemVM>();
        //   ProfileId = profileId;
        //    Date = DateTimeentryDate);
        //}

        public int ID { get; set; }
        public string Date { get; set; } = DateTime.Today.ToShortDateString();
        public int ProfileId { get; set; }
        public List<FoodItemVM> FoodItems { get; set; }

        public string TotalCalories { get; set; } = "0";
        public string TotalFat { get; set; } = "0";
        public string TotalProtein { get; set; } = "0";
        public string TotalCarbs { get; set; } = "0";
    }
}
