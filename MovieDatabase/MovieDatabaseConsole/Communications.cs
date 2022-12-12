
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieDatabaseDTO;
using MovieDatabaseDomain;
using MovieDatabaseConsole;


namespace MovieDatabaseConsole
{
    public static class Communications
    {
        // Console.WriteLine with fields
        public static void TalkToUser(string theText, string theFieldValue)
        {
            Console.WriteLine($"{theText} {theFieldValue}");
        }

        // Console.WriteLine with no field values
        public static void TalkToUser(string theText)
        {
            Console.WriteLine($"{theText}");
        }

        // Console.ReadLine 
        public static string ListenToUser()
        {
            return Console.ReadLine().Trim();
        }

        public static void ThankYouAndGoodbye()
        {
            Console.WriteLine($"Thank you for visiting Movie Database today.{Environment.NewLine}");
            Console.WriteLine("Please come back another time.");
            Environment.Exit(0);
        }


    }
}
