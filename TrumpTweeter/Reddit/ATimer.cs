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

        private static void CallImageScraper(object sender, ElapsedEventArgs e)
        {
            var reddit = new Reddit();
            reddit.ConnectToReddit();
        }

        private static int RandomizeRedditTimer()
        {
            Random randomizeMinutes = new Random();
            int randomMinutes = randomizeMinutes.Next(15, 30);

            return randomMinutes;
        }        
    }
}
