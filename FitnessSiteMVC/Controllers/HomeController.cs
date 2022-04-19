using AutoMapper;
using FitnessSiteMVC.Data;
using FitnessSiteMVC.Models;
using FitnessSiteMVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;


        public HomeController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [AllowAnonymous]
        public IActionResult Index()
        {
            EntryVM newEntry = new EntryVM();
            

            if (User.Identity.IsAuthenticated)
            {
                TempData["Date"] = DateTime.Today;
                var profile = _context.Profiles.Where(p => p.Name == User.Identity.Name).FirstOrDefault();
                var entry = _context.Entries.Include(f => f.FoodItems)
                    .ThenInclude(n => n.FoodNutrients)
                    .Where(f => f.Date == DateTime.Today && f.ProfileId.Equals(profile.Id))
                    .FirstOrDefault();
                TempData["ProfileId"] = profile.Id.ToString();
                if (entry == null)
                {
                   
                    
                    return View(newEntry);
                }

                
                _context.SaveChanges();

                var model = _mapper.Map<EntryVM>(entry);
                return View(model);
            }
            
            return View(newEntry);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public PartialViewResult GetEntryByDate(string date,int Profileid)
        {

            TempData["Date"] = date;
            var Entrydate = DateTime.Parse(date);
            Entrydate = Entrydate.ToLocalTime().Date;
            var entry = _context.Entries.Include(e => e.FoodItems).ThenInclude(e => e.FoodNutrients).Where(e=> e.ProfileId == Profileid && e.Date == Entrydate).FirstOrDefault();
            if (entry == null || entry.FoodItems.Count == 0)
            {
                return PartialView("_EmptyEntry");
            }
            var model = _mapper.Map<EntryVM>(entry);
            return PartialView("_FoodItemEntry", model.FoodItems);
        }
        [Authorize]
        public PartialViewResult GetEntryTotals(string date , int ProfileId)
        {
            var Entrydate = DateTime.Parse(date).Date;
            var entry = _context.Entries.Include(e => e.FoodItems).ThenInclude(e => e.FoodNutrients).Where(e => e.ProfileId == ProfileId && e.Date == Entrydate).FirstOrDefault();
            if (entry == null)
            {
                var emptyEntry = new Entry();
                return PartialView("_EntryTotals",emptyEntry);
            }
            var model = _mapper.Map<EntryVM>(entry);
            return PartialView("_EntryTotals", model);
            
        }
    }
}
