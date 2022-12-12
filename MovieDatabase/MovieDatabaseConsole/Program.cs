using MovieDatabaseDTO;
using MovieDatabaseDomain;
using MovieDatabaseConsole;


MovieInteractor movieInteractor = new MovieInteractor();
bool searchMovies = true;

while (searchMovies)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Communications.TalkToUser($"Welcome to The Movie Database!{Environment.NewLine}");
        Console.WriteLine($"{"A",-1} - See list of Movies");
        Console.WriteLine($"{"G",-1} - Search movies by Genre");
        Console.WriteLine($"{"T",-1} - Search movies by Title");
        Console.WriteLine($"{"Q",-1} or any other key to Quit");
        Console.ResetColor();

        string userSearch = Communications.ListenToUser();
        MovieSearchRequest(userSearch);

        Console.ForegroundColor = ConsoleColor.Green;
        Communications.TalkToUser(
            $"{Environment.NewLine}Would you like to search again? Type \"y\" or any other key to exit!");
        Console.ResetColor();

        searchMovies = Communications.ListenToUser() == "y";

        if (!searchMovies)
        {
            Communications.ThankYouAndGoodbye();
        }
    }
    catch (Exception)
    {
        searchMovies = false;
        Communications.TalkToUser($"An Error occurred, Movie Database must close!{Environment.NewLine}");
        Communications.ThankYouAndGoodbye();
    }
}


void LoadMovieData()
{
    foreach (Movie movie in BuildItemCollection())
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

List<Movie> BuildItemCollection()
{
    List<Movie> initialItems = new List<Movie>
    {
        new Movie() {Title = "Flight Me", Genre = "Action", Runtime = 193},
        new Movie() {Title = "Army of The Living", Genre = "Comedy", Runtime = 184},
        new Movie() {Title = "6 Above Ground", Genre = "Thriller", Runtime = 177},
        new Movie() {Title = "Dorbius", Genre = "Science Fiction", Runtime = 103},
        new Movie() {Title = "Happy Dream On Elm Street", Genre = "Horror", Runtime = 152}
    };
    return initialItems;
}

void DisplayAllItems()
{
    Console.WriteLine();
    Console.WriteLine("The following items are in the database");
    foreach (Movie movie in movieInteractor.GetAllItems())
    {
        Console.WriteLine($" - {movie.Title}, {movie.Genre}, runtime of {movie.Runtime} minutes!");
    }
}

void DisplayAllItemsReturnedByTitleOrGenre(List<Movie> movies)
{
    if (movies.Count == 0)
    {
        Communications.TalkToUser("There are no movies that match your search text!");
        return;
    }
    
    foreach (Movie movie in movies)
    {
        Console.WriteLine($" - {movie.Title}, {movie.Genre}, runtime of {movie.Runtime} minutes!");
    }
}

void MovieSearchRequest(string whatToDo)
{
    switch (whatToDo)
    {
        case "G":
        case "g":
            Communications.TalkToUser("You selected search by genre. Please enter Genre!");
            string searchTextGenre = Communications.ListenToUser();
            if (searchTextGenre != "")
            {
                List<Movie> moviesByGenre = movieInteractor.GetAllItemsGenre(searchTextGenre);
                DisplayAllItemsReturnedByTitleOrGenre(moviesByGenre);
                break;
            }
            Communications.TalkToUser(
                $"Your entry was invalid and Movie Database will now close!{Environment.NewLine}");
            Communications.ThankYouAndGoodbye();
            break;
        case "T":
        case "t":
            Communications.TalkToUser("You selected search by title. Please enter Title!");
            string searchTextTitle = Communications.ListenToUser();
            if (searchTextTitle != "")
            {
                List<Movie> moviesByTitle = movieInteractor.GetAllItemsByTitle(searchTextTitle);
                DisplayAllItemsReturnedByTitleOrGenre(moviesByTitle);
                break;
            }
            Communications.TalkToUser(
                $"Your entry was invalid and Movie Database will now close!{Environment.NewLine}");
            Communications.ThankYouAndGoodbye();
            break;
        case "A":
        case "a":
            DisplayAllItems();
            break;
        case "q":
        case "Q":
            Communications.ThankYouAndGoodbye();
            break;
        default:
            Communications.ThankYouAndGoodbye();
            break;
    }
}