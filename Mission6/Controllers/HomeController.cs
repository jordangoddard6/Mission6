using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Goddard.Models;

namespace Mission06_Goddard.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;

        public HomeController(MovieContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index() // Returns home page view
        {
            return View();
        }

        public IActionResult GetToKnowJoel() // Returns "Get to Know Joel" view
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie() // Returns blank "MovieForm" view
        {
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View("MovieForm", new Movie());
        }

        [HttpPost]
        public IActionResult AddMovie(Movie newMovie) /* If input valid, creates new movie in database and returns to "MovieCollection" view.
                                                       * Otherwise, returns same "MovieForm" view with errors */
        {
            if (ModelState.IsValid) // Valid input: adds to database
            {
                _context.Movies.Add(newMovie);
                _context.SaveChanges();
                return RedirectToAction("MovieCollection");
            }
            else // Invalid input: Reload form with errors
            {
                ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
                return View("MovieForm", newMovie);
            }

        }

        public IActionResult MovieCollection() // Returns "MovieCollection" view with list of all movies
        {
            List<Movie> allMovies = _context.Movies.OrderBy(x => x.Title).Include(x => x.Category).ToList();

            return View(allMovies);
        }

        [HttpGet]
        public IActionResult EditMovie(int id) // Returns "MovieForm" view with fields filled with info about movie to be edited
        {
            Movie movieToEdit = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            
            return View("MovieForm", movieToEdit);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie editedMovie) /* If input valid, posts updated info about movie to database and returns to "MovieCollection" view.
                                                           * Otherwise, returns same "MovieForm" view with errors */
        {
            if (ModelState.IsValid)
            {
                _context.Update(editedMovie);
                _context.SaveChanges();

                return RedirectToAction("MovieCollection");
            }
            else
            {
                ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

                return View("MovieForm", editedMovie);
            }

        }

        [HttpGet]
        public IActionResult DeleteMovie(int id) // Returns "DeleteMovie" view with info about movie to be deleted
        {
            Movie movieToDelete = _context.Movies.Single(x => x.MovieId == id);

            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult PostDeleteMovie(int id) // Removes movie from database and returns to "MovieCollection" view
        {
            Movie movieToDelete = _context.Movies.Single(x => x.MovieId == id);
            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();

            return RedirectToAction("MovieCollection");
        }
    }
}
