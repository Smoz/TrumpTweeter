using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace TrumpTweeter
{
    class BTimer
    {
        static System.Timers.Timer _ttimer;

        public static void TwitterTimer()
        {
            _ttimer = new System.Timers.Timer(TimeSpan.FromMinutes(RandomizeTwitterTimer()).TotalMilliseconds)
            {
                AutoReset = true
            };
            _ttimer.Elapsed += new System.Timers.ElapsedEventHandler(CallNewTweets);
            _ttimer.Start();
        }

        private static void CallNewTweets(object sender, ElapsedEventArgs e)
        {
            var twitter = new Twitter();
            twitter.NewTweetsAsync();
        }

        public static int RandomizeTwitterTimer()
        {
            Random randomizeMinutes = new Random();

            int randomMinutes = randomizeMinutes.Next(5, 10);
            return randomMinutes;
        }
    }
}
