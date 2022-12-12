using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MovieDatabaseDTO;

namespace MovieDatabaseRepository
{
    public class MoviesRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

        public MoviesRepository()
        {
            BuildOptions();
        }

        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DungeonManager"));
        }

        public bool AddMovie(Movie movieToAdd)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                //determine if item exists
                Movie existingItem = db.Movies.FirstOrDefault(x => x.Title.ToLower() == movieToAdd.Title.ToLower());

                if (existingItem == null)
                {
                    // doesn't exist, add it
                    db.Movies.Add(movieToAdd);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<Movie> GetAllMovies()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.Movies.ToList();
            }
        }

        public List<Movie> GetItemByTitle(string title)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.Movies.Where(x => x.Title.Contains(title)).Select(x => x).ToList();
            }
        }


        public List<Movie> GetItemByGenre(string genre)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.Movies.Where(x => x.Genre.Contains(genre)).Select(x => x).ToList();
            }
        }
    }
}