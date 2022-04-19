using FitnessSiteMVC.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace FitnessSiteMVC.API
{
    public class SearchResultsProcessor
    {
        string APIkey = Startup.ApiKey;

        public async Task<FoodSearchResults> LoadSearchResults(string q)
        {
            string urlParameters = $"/v1/foods/search?api_key={APIkey}&query={q}&pageSize=15";
            string url = ApiHelper.ApiClient.BaseAddress.AbsoluteUri + urlParameters;
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var results = JsonConvert.DeserializeObject<FoodSearchResults>(json);


                    return results;
                }

                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
