using FitnessSiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Utility
{
    public static class Calculator
    {
        public static double CalculateBMR(int height, double weight, string gender, double age, double AL = 1)
        {
            double bmr;
            if (gender == "male")
            {
                bmr = (10 * weight) + (6.25 * height) - (5 * age) + 5;
                bmr = bmr * (AL);
                return Math.Round(bmr);
            }
            else
            {
                bmr = 447.593 + (9.247 * weight) + (3.098 * height) - (4.330 * age);
                bmr = bmr * (AL);
                return Math.Round(bmr);
            }

        }

        public static double CalculateBMI(int height, double weight)
        {
            double bmi = weight / Math.Pow(height, 2);
            bmi = bmi * 10000;
            return Math.Round(bmi, 2);
        }

        public static void CalculateTotal(List<FoodItem> items)
        {
            double TotalCalories = 0;
            double TotalCarbs = 0;
            double TotalFat = 0;
            double TotalProtein = 0;

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
                            TotalProtein += nutrient.Value;
                            break;
                        case "Energy":
                            TotalCalories += nutrient.Value;
                            break;
                        case "Total lipid (fat)":
                            TotalFat += nutrient.Value;
                            break;
                        case "Carbohydrate, by difference":
                            TotalCarbs += nutrient.Value;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}

