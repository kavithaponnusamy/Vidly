using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public virtual Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }
    }
}