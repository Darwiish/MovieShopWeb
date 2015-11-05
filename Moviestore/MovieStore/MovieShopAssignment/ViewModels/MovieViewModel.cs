﻿using MovieShopAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopAssignment.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}