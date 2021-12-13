using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class Drink
    {
        public int Id { get; set; }

        [Display(Name = "News title")]
        [Required(ErrorMessage = "Error, invalid title!!!")]
        [MinLength(2, ErrorMessage = "Error, min lenght 8 letters!")]
        [MaxLength(100, ErrorMessage = "Error, max length 100 letters!")]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        
        
        
        [Display(Name = "News content text")]
        [Required(ErrorMessage = "Error, invalid content!!!")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        //[Display(Name = "Url for poster")]
        //[DataType(DataType.Upload, ErrorMessage = "Incorrect image url!")]
        public string PosterUrl { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Error, invalid category!!!")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Error, invalid category!!!")]
        public int Price { get; set; }

        [Display(Name ="Category")]
        [Required(ErrorMessage = "Error, invalid category!!!")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public DateTime Date { get; set; }

    }
}
