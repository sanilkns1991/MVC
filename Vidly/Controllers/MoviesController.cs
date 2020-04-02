using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
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

        // Showing all Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        // Create new Movie
        public ActionResult Create()
        {
            var movieViewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", movieViewModel);
        }

        // Edit one movie
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(c => c.Id == id);
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            if (movie == null)
                return HttpNotFound();
            return View("MovieForm", viewModel);
        }

        // Save new or existing
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);

            }
            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.NumberInStock = movie.NumberInStock;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.DateAdded = movie.DateAdded;
                movieInDB.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }



    }
}