using AutoMapper;
using FitnessSiteMVC.Data;
using FitnessSiteMVC.Models;
using FitnessSiteMVC.Models.ViewModels;
using FitnessSiteMVC.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public ProfileController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index(int id)
        {
            var entity = _context.Profiles.Where(p => p.Name == @User.Identity.Name).FirstOrDefault();
            var model = _mapper.Map<ProfileVM>(entity);

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(ProfileVM model)
        {
            var entity = _mapper.Map<Models.Profile>(model);
            entity.Activitylevel = entity.Activitylevel;
            entity.BMI = Calculator.CalculateBMI(entity.Height, entity.Weight);
            entity.BMR = Calculator.CalculateBMR(entity.Height, entity.Weight, entity.Gender, entity.Age, entity.Activitylevel);
            _context.Profiles.Add(entity);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            var item = _context.Profiles.Find(id);
            var model = _mapper.Map<ProfileVM>(item);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProfileVM model)
        {
            var entity = _mapper.Map<Models.Profile>(model);
            entity.BMI = Calculator.CalculateBMI(entity.Height, entity.Weight);
            entity.BMR = Calculator.CalculateBMR(entity.Height, entity.Weight, entity.Gender, entity.Age, entity.Activitylevel);
            _context.Profiles.Update(entity);
            _context.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }
    }
}
