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
        public static string consumerKey = "2J78Z9plJmSjpqNEazBPUqWa8";
        public static string consumerSecret = "t20mxNim4PFDHLfD2EmlLJqYC2ypPfvys5quSXP9RFWhkWMFj9";
        public static string accessToken = "895911288781639680-SDjYnqMb9zERLaed8WwEtv323yqmmoz";
        public static string accessTokenSecret = "8PT5lmK8OR67bSr1up2YwJLSMolpXi0mHGnJDc9fOVEcL";

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

            // User authentication happens
            UserAuthentication();            

            var reddit = new Reddit();
            reddit.ConnectToReddit();
            Console.ReadKey();
        }

        // Twitter account authentication happens here

        static void UserAuthentication()
        {
            string consumerKey = Globals.consumerKey;
            string consumerSecret = Globals.consumerSecret;
            string accessToken = Globals.accessToken;
            string accessTokenSecret = Globals.accessTokenSecret;

            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);

            // Here we'll call the reddit connection 
            // method and once connected we call the
            // images/memes scraper
            // Once something has been scraped the
            // tweet will be tweeted

            
        }
    }
}
