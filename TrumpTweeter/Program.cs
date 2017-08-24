using System;

// Objective: Scrape memes/images from r/The_Donald
// and create tweets out of them to send from the
// TrumpTweeterBot account with relevant hashtags
// and hopefully funny text.

namespace TrumpTweeter
{
    class Program
    {
        static void Main(string[] args)
        {            

            Greeting();            
            Console.ReadLine();
        }

        
        // A nice greeting as well as a central place
        // to call all our methods.

        static void Greeting()
        {
            Console.WriteLine("Hello and welcome to the TrumpTweeter 9000!");
            Console.WriteLine("Let's get started. Beep boop boop...");

            // Connects to Reddit and adds new tweets to database.
            // Make this an aysnc process
            var reddit = new Reddit();
            reddit.ConnectToReddit();

            // Opens Db, grabs one Tweet
            // that hasn't been posted and publishes it
            // to Twitter.

            var twitter = new Twitter();
            twitter.NewTweetsAsync();

            Console.ReadKey();
        }
    }
}
