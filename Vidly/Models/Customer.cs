﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//model folder should be reserved for DOMAIN classes.

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}