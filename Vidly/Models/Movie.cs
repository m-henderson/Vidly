using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public Genre Genres { get; set; }

        [Required]
        public byte GenreId { get; set; }
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [_1To20NumberOfMoviesInStock]
        public byte NumberInStock { get; set; }
        public byte NumberAvailable { get; set; }
    }
}