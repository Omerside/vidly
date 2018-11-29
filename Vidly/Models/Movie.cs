using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public Nullable<DateTime> ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public Nullable<DateTime> AddedDate { get; set; }
        public int Stock { get; set; }
    }
}