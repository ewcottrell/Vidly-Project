using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MovieRepository movieRepository;

        public MoviesController(MovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public ViewResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }
        public ActionResult New()
        {
            
            return View();
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {


                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }

        public ActionResult Add(string name, int year, string genre)
        {
            Movie movie = new Movie() { Name = name, Year = year, Genre = genre };
            movieRepository.AddMovie(movie);
            return RedirectToAction("Index", "Movies");

        }

        // GET: movies/random
        //public ViewResult Random()
        //{
        //    var movie = new Movie { Name = "Shrek!" };

        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer1"},
        //        new Customer { Name = "Customer2" }
        //    };


        //    RandomMovieViewModel viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}


    }
}
