using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class Coins
    {
        public int Id { get; set; }
        
        [Display(Name = "Value")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int Value { get; set; }
        [Display(Name = "IsValue")]
        public bool IsValue { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Error, invalid category!!!")]
        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
    }
}
