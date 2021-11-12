using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genres

            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);

            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => id == m.Id);
            if (movie.Id == 0)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Index()
        {
            var model = new MoviListViewModel();
             model.Movies = _context.Movies.ToList();

            model.Genres = _context.Genres.ToList();
            return View(model);

        }
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.SingleOrDefault(m => m.Id == id);
            _context.Genres.ToList();
            if (movies == null)
                return HttpNotFound();
            return View(movies);
        }
    }
}