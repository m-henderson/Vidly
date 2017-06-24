﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

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
            //var movie = _context.Movies.ToList();
            //var viewModel = new NewMovieViewModel
            //{

            //};
            return View();
        }
    }
}