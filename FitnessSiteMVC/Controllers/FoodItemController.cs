using AutoMapper;
using FitnessSiteMVC.API;
using FitnessSiteMVC.Data;
using FitnessSiteMVC.Models;
using FitnessSiteMVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Controllers
{
    [Authorize]
    public class FoodItemController : Controller
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public FoodItemController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [Route("FoodItem")]
        public IActionResult Search(int id)
        {
            ViewBag.Id = id;

            return View();
        }
        [HttpPost]
        public async Task<PartialViewResult> Search(string q,int id)
        {
            ApiHelper.InitalizeClient();
            var processor = new SearchResultsProcessor();
            var results = await processor.LoadSearchResults(q);
            foreach (var item in results.SearchResults)
            {
                item.EntryId = id;
                item.FoodNutrients = item.FoodNutrients.Where(i => i.NutrinetNumber == "203" ||
                                                                    i.NutrinetNumber == "204" ||
                                                                    i.NutrinetNumber == "205" ||
                                                                    i.NutrinetNumber == "208").ToList();

            }

            return PartialView("_SearchResults",results);
        }



        public IActionResult Create(FoodItem model)
        {
            var item = _mapper.Map<FoodItemVM>(model);
            return View(item);
        }

        [HttpPost]
        public IActionResult Save(FoodItemVM model)
        {
            var entity = _mapper.Map<FoodItem>(model);
            var currentProfileId = int.Parse((string)TempData["ProfileId"]);
            DateTime SelectedEntryDate = (DateTime)TempData["date"];
            var entry = _context.Entries.Where(e => e.ProfileId == currentProfileId && e.Date.Date == SelectedEntryDate.ToLocalTime().Date).FirstOrDefault();

            if (entry == null)
            {
                var newEntry = new Entry(SelectedEntryDate.ToLocalTime().Date, currentProfileId);
                newEntry.FoodItems.Add(entity);
                newEntry.AddTotal(entity);
                _context.Entries.Add(newEntry);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");

            }
            else
            {
                entry.FoodItems.Add(entity);
                entry.AddTotal(entity);
                _context.Entries.Update(entry);
                _context.SaveChanges();


                return RedirectToAction("Index", "Home");
            }

            
        }


        public IActionResult Edit(int id)
        {
            var entity = _context.FoodItems.Include("FoodNutrients").Where(p => p.Id == id).FirstOrDefault();
            var model = _mapper.Map<FoodItemVM>(entity);
            return View(model);
        }

        [HttpPost]

        public IActionResult Edit(FoodItemVM item)
        {
            var model = _mapper.Map<FoodItem>(item);
            var entity = _context.FoodItems.Include("FoodNutrients").Where(p => p.Id == model.Id).FirstOrDefault();

            if (entity != null)
            {

                entity.FoodNutrients.Clear();
                foreach (var nutrient in model.FoodNutrients)
                {
                    entity.FoodNutrients.Add(nutrient);
                }
                _context.Entry(entity).CurrentValues.SetValues(model);
            }

            var entry = _context.Entries.Include(f => f.FoodItems)
                .ThenInclude(n => n.FoodNutrients)
                .Where(e => e.ID == entity.EntryId).FirstOrDefault();

            entry.CalculateTotal(entry.FoodItems);

            _context.SaveChanges();

            

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var entity = _context.FoodItems.Include("FoodNutrients").Where(item => item.Id == id).FirstOrDefault();
            _context.FoodNutrients.RemoveRange(entity.FoodNutrients);
            _context.FoodItems.Remove(entity);

            var entry = _context.Entries.Find(entity.EntryId);
            entry.ReduceTotal(entity);
            
            _context.SaveChanges();

           

            return NoContent();
        }


    }
}
