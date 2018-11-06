using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required] //Makes it so "Name" is not nullable in the DB
        [StringLength(255)] //Makes it so "Name" can only be up to 255 characters
        public string Name { get; set; }

        
        public Nullable<DateTime> DateOfBirth { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}