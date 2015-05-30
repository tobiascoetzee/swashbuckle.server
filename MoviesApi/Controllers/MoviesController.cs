using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Synopsis =
                    "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                YearOfRelease = "1972"
            },
            new Movie
            {
                Id = 2,
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Synopsis =
                    "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                YearOfRelease = "1972"
            },
            new Movie
            {
                Id = 3,
                Title = "Schindler's List",
                Director = "Steven Spielberg",
                Synopsis =
                    "In Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                YearOfRelease = "1993"
            },
            new Movie
            {
                Id = 4,
                Title = "Raging Bull",
                Director = "Francis Ford Coppola",
                Synopsis =
                    "An emotionally self-destructive boxer's journey through life, as the violence and temper that leads him to the top in the ring, destroys his life outside it.",
                YearOfRelease = "1980"
            },
            new Movie
            {
                Id = 5,
                Title = "Casablanca",
                Director = "Francis Ford Coppola",
                Synopsis =
                    "Set in unoccupied Africa during the early days of World War II: An American expatriate meets a former lover, with unforeseen complications.",
                YearOfRelease = "1942"
            }
        };

        /// <summary>
        /// Returns all movies
        /// </summary>
        [Route("")]
        [ResponseType(typeof(List<Movie>))]
        public IHttpActionResult Get()
        {
            return Ok(movies);
        }

        /// <summary>
        /// Returns a single movie for an id
        /// </summary>
        /// <remarks>You have to supply a valid id.</remarks>
        /// <response code="404">No movie with the given id exists.</response>
        [Route("{id}", Name = "GetMovieById")]
        [ResponseType(typeof(Movie))]
        public IHttpActionResult Get(int id)
        {
            var movie = movies.FirstOrDefault(p => p.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        /// <summary>
        /// Create a new movie.
        /// </summary>
        /// <remarks>Cannot reuse an existing id.</remarks>
        /// <response code="405">Cannot add a new movie with an existing id.</response>
        [Route("")]
        [ResponseType(typeof(Movie))]
        public IHttpActionResult Post([FromBody] Movie movie)
        {
            var foundMovie = movies.FirstOrDefault(p => p.Id == movie.Id);

            if (foundMovie != null)
            {
                return BadRequest("movie already exists");
            }

            movies.Add(movie);

            string uri = Url.Link("GetMovieById", new {id = movie.Id});

            return Created(uri, movie);
        }
    }
}
