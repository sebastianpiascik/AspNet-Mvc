using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetWebApplication.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter Type Name")]
        [Display(Name = "Type Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Details")]
        [StringLength(100, ErrorMessage = "{0} musi zawierać co najmniej następującą liczbę znaków: {2}.", MinimumLength = 50)]
        public string Details { get; set; }

        public ICollection<Bike> Bikes { get; set; }
    }
}