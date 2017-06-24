using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genres).ToList();

            return View(movies);							
		}
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(c => c.Genres).SingleOrDefault(c => c.Id == id);

            return View(movies);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var movie = _context.Movies.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genres
            };
            return View("new", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                


            }

            var viewModel = new NewMovieViewModel
            {
                Movie = movie
            };

            return View("New", viewModel);
        }
    }
}