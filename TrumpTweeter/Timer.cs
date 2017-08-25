using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrumpTweeter
{
    static class Timer
    {
        public static int RandomizeRedditTimer()
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

        public static int RandomizeTwitterTimer()
        {
            Random randomizeMinutes = new Random();

            int randomMinutes = randomizeMinutes.Next(5, 10);
            return randomMinutes;
        }
    }
}
