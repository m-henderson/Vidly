﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

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

            ViewBag.Heading = "Add Movie";

            return View("MovieForm", viewModel);
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

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genres = movie.Genres;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
                _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            ViewBag.Heading = "Edit Movie";
            return View("MovieForm", viewModel);

        }
    }
}