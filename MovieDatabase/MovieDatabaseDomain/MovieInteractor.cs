using MovieDatabaseRepository;
using MovieDatabaseDTO;

namespace MovieDatabaseDomain
{
    public class MovieInteractor
    {
        private MoviesRepository _repository;

        public MovieInteractor()
        {
            _repository = new MoviesRepository();
        }

        public bool AddNewMovie(Movie movieToAdd)
        {
            if (string.IsNullOrEmpty(movieToAdd.Title) || string.IsNullOrEmpty(movieToAdd.Genre))
            {
                throw new ArgumentException("Title and Genre must contain valid text.");
            }

            return _repository.AddMovie(movieToAdd);
        }

        public List<Movie> GetAllItems()
        {
            return _repository.GetAllMovies();
        }

        public List<Movie> GetAllItemsByTitle(string title)
        {
            return _repository.GetItemByTitle(title);
        }

        public List<Movie> GetAllItemsGenre(string genre)
        {
            return _repository.GetItemByGenre(genre);
        }
    }
}