using MovieDatabaseDTO;
using MovieDatabaseDomain;
using MovieDatabaseConsole;


MovieInteractor movieInteractor = new MovieInteractor();
MovieNavigation movieNav = new MovieNavigation();
bool keepSearchingMovies = true;

while (keepSearchingMovies)
{
    try
    {
        movieNav.DisplayMenu();
        string userSearch = MovieCommunications.ListenToUser();
        movieNav.MovieSearchRequest(userSearch);
        movieNav.SearchMoviesAgain(keepSearchingMovies);
    }
    catch (Exception)
    {
        keepSearchingMovies = false;
        MovieCommunications.ThankYouAndGoodbyeError();
    }
}

void LoadMovieData()
{
    List<Movie> initialItems = new List<Movie>
    {
        new Movie() {Title = "Fight Me Now", Genre = "Action", Runtime = 193},
        new Movie() {Title = "Army of The UnLiving", Genre = "Comedy", Runtime = 184},
        new Movie() {Title = "7 Above Ground", Genre = "Thriller", Runtime = 177},
        new Movie() {Title = "Morbius", Genre = "Science Fiction", Runtime = 103},
        new Movie() {Title = "No Sleep On Elm Street", Genre = "Horror", Runtime = 152}
    };

    foreach (Movie movie in initialItems)
    {
        if (movieInteractor.AddNewMovie(movie))
        {
            Console.WriteLine($"{movie.Title} was added to the database.");
        }
        else
        {
            Console.WriteLine($"{movie.Title} was NOT added to the database.");
        }
    }
}