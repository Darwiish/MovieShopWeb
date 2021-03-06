﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreMVCDto
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string TralierUrl { get; set; }
        public virtual IEnumerable<OrderLine> OrderLines { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
