using Figgle;

namespace MovieDatabaseConsole
{
    public static class MovieCommunications
    {
        public static void TalkToUserWithField(string theText, string theFieldValue)
        {
            Console.WriteLine($"{theText} {theFieldValue}");
        }

        public static void TalkToUser(string theText)
        {
            Console.WriteLine($"{theText}");
        }

        public static string ListenToUser()
        {
            return Console.ReadLine()!.Trim();
        }

        public static void ThankYouAndGoodbye()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(FiggleFonts.Avatar.Render("Movie Database!"));
            Console.WriteLine($"Thank you for visiting Movie Database today.{Environment.NewLine}");
            Console.ResetColor();
            Environment.Exit(0);
        }

        public static void ThankYouAndGoodbyeError()
        {
            Console.WriteLine($"An Error occurred, Movie Database must close!{Environment.NewLine}");
            ThankYouAndGoodbye();
        }
    }
}