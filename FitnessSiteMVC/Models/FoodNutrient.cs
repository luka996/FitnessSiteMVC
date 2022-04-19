using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Models
{
    public class FoodNutrient
    {
        public int Id { get; set; }
        [JsonProperty("nutrientName")]
        [StringLength(100)]
        public string NutrientName { get; set; }
        public string UnitName { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
        [JsonProperty("nutrientNumber")]
        [NotMapped]
        public string NutrinetNumber { get; set; }
        [ForeignKey("FoodItem")]
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }
    }
}
