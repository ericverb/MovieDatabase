using MovieDatabaseDomain;
using MovieDatabaseDTO;
using Figgle;

namespace MovieDatabaseConsole
{
    public class MovieNavigation
    {
        readonly MovieInteractor movieInteractor = new MovieInteractor();

        public void DisplayAllItems()
        {
            MovieCommunications.TalkToUser($"The following items are in the database!{Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (Movie movie in movieInteractor.GetAllItems())
            {
                MovieCommunications.TalkToUser(
                    $"Title: {movie.Title} - Genre: {movie.Genre} -  Runtime of {movie.Runtime} minutes!");
            }

            Console.ResetColor();
        }

        public void DisplayAllItemsReturnedByTitleOrGenre(List<Movie> movies)
        {
            if (movies.Count == 0)
            {
                MovieCommunications.TalkToUser("There are no movies that match your search text!");
                return;
            }

            foreach (Movie movie in movies)
            {
                MovieCommunications.TalkToUser(
                    $"Title: {movie.Title} - Genre: {movie.Genre} - Runtime of {movie.Runtime} minutes!");
            }
        }

        public void MovieSearchRequest(string menuSelection)
        {
            switch (menuSelection)
            {
                case "G":
                case "g":
                    Console.Clear();
                    MovieCommunications.TalkToUser("You selected search by genre. Please enter Genre!");
                    string searchTextGenre = MovieCommunications.ListenToUser();
                    if (searchTextGenre != "")
                    {
                        List<Movie> moviesByGenre = movieInteractor.GetAllItemsGenre(searchTextGenre);
                        DisplayAllItemsReturnedByTitleOrGenre(moviesByGenre);
                        break;
                    }

                    MovieCommunications.TalkToUser(
                        $"Your entry was invalid and Movie Database will now close!{Environment.NewLine}");
                    MovieCommunications.ThankYouAndGoodbye();
                    break;
                case "T":
                case "t":
                    Console.Clear();
                    MovieCommunications.TalkToUser("You selected search by title. Please enter Title!");
                    string searchTextTitle = MovieCommunications.ListenToUser();
                    if (searchTextTitle != "")
                    {
                        List<Movie> moviesByTitle = movieInteractor.GetAllItemsByTitle(searchTextTitle);
                        DisplayAllItemsReturnedByTitleOrGenre(moviesByTitle);
                        break;
                    }

                    MovieCommunications.TalkToUser(
                        $"Your entry was invalid and Movie Database will now close!{Environment.NewLine}");
                    MovieCommunications.ThankYouAndGoodbye();
                    break;
                case "A":
                case "a":
                    Console.Clear();
                    DisplayAllItems();
                    break;
                case "q":
                case "Q":
                    Console.Clear();
                    MovieCommunications.ThankYouAndGoodbye();
                    break;
                default:
                    Console.Clear();
                    MovieCommunications.ThankYouAndGoodbye();
                    break;
            }
        }

        public void DisplayMenu()
        {
            Console.SetWindowSize(160, 50);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            MovieCommunications.TalkToUser(FiggleFonts.Avatar.Render("Welcome to MovieDatabase!"));
            MovieCommunications.TalkToUser($"{"A",-1} - See list of Movies");
            MovieCommunications.TalkToUser($"{"G",-1} - Search movies by Genre");
            MovieCommunications.TalkToUser($"{"T",-1} - Search movies by Title");
            MovieCommunications.TalkToUser($"{"Q",-1} or any other key to Quit");
            Console.ResetColor();
        }

        public void SearchMoviesAgain(bool searchMovies)
        {
            MovieCommunications.TalkToUser(
                $"{Environment.NewLine}Would you like to search again? Type \"y\" or any other key to exit!");

            searchMovies = MovieCommunications.ListenToUser() == "y";
            Console.Clear();

            if (!searchMovies)
            {
                MovieCommunications.ThankYouAndGoodbye();
            }
        }
    }
}