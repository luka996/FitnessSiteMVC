using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Models
{
    public class Entry
    {
        public Entry()
        {
            FoodItems = new List<FoodItem>();
        }

        public Entry(DateTime entryDate, int profileId)
        {
            FoodItems = new List<FoodItem>();
            ProfileId = profileId;
            Date = entryDate;
        }

        public int ID { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;

        [ForeignKey("Profile")]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public List<FoodItem> FoodItems { get; set; }

        public double TotalCalories { get; set; } = 0;
        public double TotalFat { get; set; } = 0;
        public double TotalProtein { get; set; } = 0;
        public double TotalCarbs { get; set; } = 0;


        public void CalculateTotal(List<FoodItem> items)
        {
            TotalCalories = 0;
            TotalCarbs = 0;
            TotalFat = 0;
            TotalProtein = 0;

            if (items.Count == 0)
            {
                return;
            }

            foreach (var item in items)
            {
                foreach (var nutrient in item.FoodNutrients)
                {
                    switch (nutrient.NutrientName)
                    {
                        case "Protein":
                            TotalProtein = Math.Round(TotalProtein + nutrient.Value, 2);
                            break;
                        case "Energy":
                            TotalCalories = Math.Round(TotalCalories + nutrient.Value, 2);
                            break;
                        case "Total lipid (fat)":
                            TotalFat = Math.Round(TotalFat + nutrient.Value, 2);
                            break;
                        case "Carbohydrate, by difference":
                            TotalCarbs = Math.Round(TotalCarbs + nutrient.Value, 2);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public void AddTotal(FoodItem item)
        {

            foreach (var nutrient in item.FoodNutrients)
            {
                switch (nutrient.NutrientName)
                {
                    case "Protein":
                        TotalProtein = Math.Round(TotalProtein + nutrient.Value, 2);
                        break;
                    case "Energy":
                        TotalCalories = Math.Round(TotalCalories + nutrient.Value, 2);
                        break;
                    case "Total lipid (fat)":
                        TotalFat = Math.Round(TotalFat + nutrient.Value, 2);
                        break;
                    case "Carbohydrate, by difference":
                        TotalCarbs = Math.Round(TotalCarbs + nutrient.Value, 2);
                        break;
                    default:
                        break;
                }
            }
        }

        public void ReduceTotal(FoodItem item)
        {

            foreach (var nutrient in item.FoodNutrients)
            {
                switch (nutrient.NutrientName)
                {
                    case "Protein":
                        TotalProtein = Math.Round(TotalProtein - nutrient.Value, 2) ;
                        break;
                    case "Energy":
                        TotalCalories = Math.Round(TotalCalories - nutrient.Value, 2);
                        break;
                    case "Total lipid (fat)":
                        TotalFat = Math.Round(TotalFat - nutrient.Value, 2);
                        break;
                    case "Carbohydrate, by difference":
                        TotalCarbs = Math.Round(TotalCarbs - nutrient.Value, 2);
                        break;
                    default:
                        break;
                }
            }
        }
    }

}


        





