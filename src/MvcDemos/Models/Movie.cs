using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemos.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public MovieGenre Genre { get; set; }
    }
}