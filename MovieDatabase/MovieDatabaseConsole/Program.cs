using MovieDatabaseDTO;
using MovieDatabaseDomain;
using MovieDatabaseConsole;


MovieInteractor movieInteractor = new MovieInteractor();
Navigation nav = new Navigation();
bool keepSearchingMovies = true;

while (keepSearchingMovies)
{
    try
    {
        nav.DisplayMenu();
        string userSearch = Communications.ListenToUser();
        nav.MovieSearchRequest(userSearch);
        nav.SearchMoviesAgain(keepSearchingMovies);
    
    }
    catch (Exception)
    {
        keepSearchingMovies = false;
        Communications.TalkToUser($"An Error occurred, Movie Database must close!{Environment.NewLine}");
        Communications.ThankYouAndGoodbye();
    }
}


void LoadMovieData()
{
    List<Movie> initialItems = new List<Movie>
    {
        new Movie() {Title = "Fight Me Now", Genre = "Action", Runtime = 193},
        new Movie() {Title = "Army of The UnLiving", Genre = "Comedy", Runtime = 184},
        new Movie() {Title = "7 Above Ground", Genre = "Thriller", Runtime = 177},
        new Movie() {Title = "Slorbius", Genre = "Science Fiction", Runtime = 103},
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

