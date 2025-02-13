using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult AddMovie() // Returns Add Movie view
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie response) // Submits form data to sqlite database and returns to home page
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return View("Index");
        }
    }
}
