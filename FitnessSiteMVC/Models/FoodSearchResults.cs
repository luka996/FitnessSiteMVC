using FitnessSiteMVC.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Models
{
    public class FoodSearchResults
    {
        [JsonProperty("foods")]
        public FoodItem[] SearchResults { get; set; }
    }
}
