using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetWebApplication.Models
{
    public class Bike
    {
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }
        [RegularExpression("^([a-zA-Z0-9 -]*)$", ErrorMessage = "Invalid Name")]
        [StringLength(100, ErrorMessage = "{0} musi zawierać co najmniej następującą liczbę znaków: {2}.", MinimumLength = 2)]
        [Required(ErrorMessage = "Enter Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Brand")]
        [Display(Name = "Brand")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Enter Weight")]
        [Range(0,100)]
        [Display(Name = "Weight")]
        public double Weight { get; set; }

        public int CurrentCategoryId { get; set; }
        public Category CurrentCategory { get; set; }
    }
}