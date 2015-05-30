using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApi.Models
{
    public class Movie
    {
        /// <summary>
        /// Movie's id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Title of the movie
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Who directed the movie
        /// </summary>
        public string Director { get; set; }
        
        /// <summary>
        /// Short description about the movie
        /// </summary>
        public string Synopsis { get; set; }
        
        /// <summary>
        /// Year it was released
        /// </summary>
        public string YearOfRelease { get; set; }
    }
}