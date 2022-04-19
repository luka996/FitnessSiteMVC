using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Models
{
    public class FoodItem
    {
        
            public FoodItem()
            {
                FoodNutrients = new List<FoodNutrient>();
            }

            public int Id { get; set; }

            [JsonProperty("lowercaseDescription")]
            [StringLength(100)]
            public string LowerDescription { get; set; }
            [JsonProperty("brandName")]
            [StringLength(100)]
            public string BrandName { get; set; }
            [JsonProperty("foodNutrients")]
            public List<FoodNutrient> FoodNutrients { get; set; }
            public double Amount { get; set; }
            [ForeignKey("Entry")]
            public int EntryId { get; set; }
            public Entry Entry { get; set; }


    }
}
