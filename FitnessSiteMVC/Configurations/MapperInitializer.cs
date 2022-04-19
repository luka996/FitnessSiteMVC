using AutoMapper;
using FitnessSiteMVC.Models;
using FitnessSiteMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Configurations
{
    public class MapperInitializer : AutoMapper.Profile
    {
        public MapperInitializer()
        {
            CreateMap<FoodItem, FoodItemVM>().ReverseMap();
            CreateMap<FoodNutrient, FoodNutrientVM>().ReverseMap();
            CreateMap<Models.Profile, ProfileVM>().ReverseMap();
            CreateMap<FoodItem, FoodItemVM>().ReverseMap();
            CreateMap<Entry, EntryVM>().ReverseMap();

        }
    }
}
