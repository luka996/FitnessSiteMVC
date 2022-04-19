using FitnessSiteMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }

           public DbSet<FoodItem> FoodItems { get; set; }
           public DbSet<FoodNutrient> FoodNutrients { get; set; }
           public DbSet<Entry> Entries { get; set; }
           public DbSet<Profile> Profiles { get; set; }


        
    }
}
