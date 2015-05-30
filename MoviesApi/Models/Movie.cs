using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Synopsis { get; set; }
        public string YearOfRelease { get; set; }
    }
}