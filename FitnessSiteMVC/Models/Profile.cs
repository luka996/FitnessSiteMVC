using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessSiteMVC.Models
{
    public class Profile
    {
        public Profile()
        {
            Entries = new List<Entry>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,272, ErrorMessage = "Height must be between 40 and 500")]
        public int Height { get; set; }
        [Required]
        [Range(40,500,ErrorMessage ="Weight must be between 40 and 500")]
        public double Weight { get; set; }
        [Required]
        [Display(Name ="Target Weight")]
        public double TargetWeight { get; set; }
        [Required]
        public string Gender { get; set; }
        public double BMR { get; set; }
        public double BMI { get; set; }
        [Required]
        [Range(10,99,ErrorMessage ="Age must be between 10 and 99")]
        public double Age { get; set; }
        [NotMapped]
        public double Activitylevel { get; set; }
        public List<Entry> Entries { get; set; }


        

    }
}
