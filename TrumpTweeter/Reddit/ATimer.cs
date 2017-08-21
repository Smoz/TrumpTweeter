using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;


namespace TrumpTweeter
{
    class ATimer
    {        
        // This is our timer method used to
        // randomize the reddit scraping
        // and twitter tweeting so we don't
        // get banned

        static System.Timers.Timer _timer;

        public static void RedditTimer()
        {
            _timer = new System.Timers.Timer(TimeSpan.FromMinutes(RandomizeRedditTimer()).TotalMilliseconds)
            {
                AutoReset = true
            };
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(CallImageScraper);
            _timer.Start();
        }

        // This method reinitializes the reddit
        // image scraper so we can get new images
        // to add to our database

        private static void CallImageScraper(object sender, ElapsedEventArgs e)
        {
            var reddit = new Reddit();
            reddit.ConnectToReddit();
        }

        // This method randomizes the times that
        // the CallImageScraper() method is
        // called

        private static int RandomizeRedditTimer()
        {
            Random randomizeMinutes = new Random();

            // Here we can set a range of numbers to select
            // a random number from
            // This number will be converted to minutes
            // and that number is passed to the RedditTimer()
            // which then will call the CallImageScraper()
            // method after that time has elapsed

            int randomMinutes = randomizeMinutes.Next(15, 30);

            return randomMinutes;
        }

        public static void TwitterTimer()
        {
            _timer = new System.Timers.Timer(TimeSpan.FromMinutes(RandomizeTwitterTimer()).TotalMilliseconds)
            {
                AutoReset = true
            };
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(CallPublishTweet);
            _timer.Start();
        }

        private static int RandomizeTwitterTimer()
        {
            Random randomizeMinutes = new Random();

            int randomMinutes = randomizeMinutes.Next(3, 10);
            return randomMinutes;
        }

        private static void CallPublishTweet(object sender, ElapsedEventArgs e)
        {
            var twitter = new Twitter();
            string title = twitter.Title;
            string image = twitter.Image;
            twitter.PublishTweet(title,image);
        }
    }

    

}
