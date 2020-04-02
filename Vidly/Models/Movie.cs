using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter Movie's name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Release Date")]
        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage ="The number in stock field is required")]
        [Range(1,20,ErrorMessage ="The field number in stock must be between 1 and 20")]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }


        public Genre Genre { get; set; }

        [Required]
        [Display(Name ="Genre")]
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
    }
}