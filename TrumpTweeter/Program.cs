using System;
using System.Threading;
using Tweetinvi;

// Objective: Scrape memes/images from r/The_Donald
// and create tweets out of them to send from the
// TrumpTweeterBot account with relevant hashtags
// and hopefully funny text.

namespace TrumpTweeter
{
    // A class for publicly accessible variables

    public static class Globals
    {
        public static string url = @"https://www.reddit.com/r/The_Donald/new/.json";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dbconnection = new DbConnection();
            dbconnection.ConnectingToDb();
            //Greeting();            
            Console.ReadLine();
        }

        
        // A nice greeting as well as a central place
        // to call all our methods.

        static void Greeting()
        {
            Console.WriteLine("Hello and welcome to the TrumpTweeter 9000!");
            Console.WriteLine("Let's get started. Beep boop boop...");          

            var reddit = new Reddit();
            reddit.ConnectToReddit();
            Console.ReadKey();
        }
    }
}
