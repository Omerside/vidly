using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        // Define the variable that will hold the DB for our application
        private ApplicationDbContext _context;

        public MoviesController()
        {
            // Reference our DB to the variable previously defined inside of the default constructor.
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            // override Dispose to dispose our assigned DB reference
            _context.Dispose();
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);

        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]

        public ActionResult New()
        {
            var genreInput = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel
            {
                genre = genreInput
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                movie = movie,
                genre = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
        }



        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }



        private IEnumerable<Movie> GetMovies()
        {
            var movies = new List<Movie>
            {
                new Movie {Name = "Shrek 1"},
                new Movie {Name = "Shek 2"}
            };
            return movies;
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }

            try
            {
                _context.SaveChanges();
            } catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Movies");
        }
    }
}