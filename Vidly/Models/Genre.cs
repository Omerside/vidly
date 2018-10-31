using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required] //Makes it so "Name" is not nullable in the DB
        [StringLength(255)] //Makes it so "Name" can only be up to 255 characters
        public String GenreName { get; set; }
    }
}