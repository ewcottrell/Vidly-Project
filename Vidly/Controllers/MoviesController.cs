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
            Movie.MovieViewModel = movieRepository.GetMovies();
            return View();
        }
        [ValidateAntiForgeryToken]
        public ActionResult Add(string name, int year, string genre, int numberinstock)
        {
            MovieViewModel movie = new MovieViewModel() { Name = name, Year = year, Genre = genre, NumberInStock = numberinstock};
            movieRepository.AddMovie(movie);
            return RedirectToAction("Index", "Movies");
        }
       
        public ActionResult AddNewMovie()
        {
            return View();
        }

        public ActionResult Delete(int Id)
        {
            movieRepository.DeleteMovie(Id);
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
