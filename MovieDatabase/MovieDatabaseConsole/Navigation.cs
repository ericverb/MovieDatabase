using MovieDatabaseDomain;
using MovieDatabaseDTO;
using Figgle;

namespace MovieDatabaseConsole
{
    public class Navigation
    {
        readonly MovieInteractor movieInteractor = new MovieInteractor();

        public void DisplayAllItems()
        {
            Communications.TalkToUser($"The following items are in the database!{Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (Movie movie in movieInteractor.GetAllItems())
            {
                Communications.TalkToUser(
                    $"Title: {movie.Title} - Genre: {movie.Genre} -  Runtime of {movie.Runtime} minutes!");
            }

            Console.ResetColor();
        }

        public void DisplayAllItemsReturnedByTitleOrGenre(List<Movie> movies)
        {
            if (movies.Count == 0)
            {
                Communications.TalkToUser("There are no movies that match your search text!");
                return;
            }

            foreach (Movie movie in movies)
            {
                Communications.TalkToUser(
                    $"Title: {movie.Title} - Genre: {movie.Genre} - Runtime of {movie.Runtime} minutes!");
            }
        }

        public void MovieSearchRequest(string whatToDo)
        {
            switch (whatToDo)
            {
                case "G":
                case "g":
                    Console.Clear();
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
                    Console.Clear();
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
                    Console.Clear();
                    DisplayAllItems();
                    break;
                case "q":
                case "Q":
                    Console.Clear();
                    Communications.ThankYouAndGoodbye();
                    break;
                default:
                    Console.Clear();
                    Communications.ThankYouAndGoodbye();
                    break;
            }
        }

        public void DisplayMenu()
        {
            Console.SetWindowSize(160, 50);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Communications.TalkToUser(FiggleFonts.Avatar.Render("Welcome to MovieDatabase!"));
            Communications.TalkToUser($"{"A",-1} - See list of Movies");
            Communications.TalkToUser($"{"G",-1} - Search movies by Genre");
            Communications.TalkToUser($"{"T",-1} - Search movies by Title");
            Communications.TalkToUser($"{"Q",-1} or any other key to Quit");
            Console.ResetColor();
        }

        public void SearchMoviesAgain(bool searchMovies)
        {
            Communications.TalkToUser(
                $"{Environment.NewLine}Would you like to search again? Type \"y\" or any other key to exit!");

            searchMovies = Communications.ListenToUser() == "y";
            Console.Clear();

            if (!searchMovies)
            {
                Communications.ThankYouAndGoodbye();
            }
        }
    }
}