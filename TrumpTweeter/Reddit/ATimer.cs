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

        static System.Timers.Timer _rtimer;
        

        public static void RedditTimer()
        {
            _rtimer = new System.Timers.Timer(TimeSpan.FromMinutes(RandomizeRedditTimer()).TotalMilliseconds)
            {
                AutoReset = true
            };
            _rtimer.Elapsed += new System.Timers.ElapsedEventHandler(CallImageScraper);
            _rtimer.Start();
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

            int randomMinutes = randomizeMinutes.Next(5, 7);

            return randomMinutes;
        }

        

        
    }

    

}
