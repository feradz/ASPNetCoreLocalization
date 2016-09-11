using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationDemo.Models
{
    public enum GenderType
    {
        [Display(Name = "None", ResourceType = typeof(Resources.DataAnnotations))]
        None,
        [Display(Name = "Male", ResourceType = typeof(Resources.DataAnnotations))]
        Male,
        [Display(Name = "Female", ResourceType = typeof(Resources.DataAnnotations))]
        Female
    }
    public class Student
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Minimul length is 5")]
        [Display(Name="Name", ResourceType = typeof(Resources.DataAnnotations))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [MinLength(5, ErrorMessage = "Minimul length is 5")]
        [Display(Name = "Surname", ResourceType = typeof(Resources.DataAnnotations))]
        public string Surname { get; set; }

        [Display(Name="Gender", ResourceType = typeof(Resources.DataAnnotations))]
        public GenderType Gender { get; set; }
    }
}
