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
        public int ID { get; set; }
        [RegularExpression("^([a-zA-Z0-9 -]*)$", ErrorMessage = "Invalid Name")]
        [StringLength(100, ErrorMessage = "{0} musi zawierać co najmniej następującą liczbę znaków: {2}.", MinimumLength = 2)]
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Brand")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Enter Weight")]
        public double Weight { get; set; }

        public int CurrentCategoryId { get; set; }
        public Category CurrentCategory { get; set; }
    }
}