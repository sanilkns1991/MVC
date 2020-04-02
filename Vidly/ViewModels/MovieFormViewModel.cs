using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter Movie's name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [Column(TypeName = "datetime2")]
        public DateTime? ReleaseDate { get; set; }


        [Required(ErrorMessage = "The number in stock field is required")]
        [Range(1, 20, ErrorMessage = "The field number in stock must be between 1 and 20")]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }


        [Required]
        [Display(Name = "Genre")]
        [ForeignKey("Genre")]
        public int? GenreId { get; set; }

        public string Title
        {
        get
            {
                return (Id != 0) ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0; // To populate the hidden field in the view page
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

    }
}