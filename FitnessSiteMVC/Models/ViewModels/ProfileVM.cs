using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Models.ViewModels
{
    public class ProfileVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 272, ErrorMessage = "Height must be between 40 and 500")]
        public string Height { get; set; }
        [Required]
        [Range(40, 500, ErrorMessage = "Weight must be between 40 and 500")]
        public string Weight { get; set; }
        [Required]
        [Display(Name = "Target Weight")]
        public string TargetWeight { get; set; }
        [Required]
        public string Gender { get; set; }
        public string BMR { get; set; }
        public string BMI { get; set; }
        [Required]
        [Range(10, 99, ErrorMessage = "Age must be between 10 and 99")]
        public double Age { get; set; }
        public string Activitylevel { get; set; }
    }
}
