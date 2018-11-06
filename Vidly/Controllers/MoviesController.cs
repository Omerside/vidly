using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
            // return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        /*
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }*/

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
    }
}