using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }

    public class MoviListViewModel
    {
        public List<Movie> Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}