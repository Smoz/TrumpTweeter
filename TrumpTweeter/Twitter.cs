using Tweetinvi;
using System.IO;
using System;
using Tweetinvi.Parameters;
using Tweetinvi.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;


namespace TrumpTweeter
{
    public class Twitter
    {
        private const string consumerKey = "2J78Z9plJmSjpqNEazBPUqWa8";
        private const string consumerSecret = "t20mxNim4PFDHLfD2EmlLJqYC2ypPfvys5quSXP9RFWhkWMFj9";
        private const string accessToken = "895911288781639680-SDjYnqMb9zERLaed8WwEtv323yqmmoz";
        private const string accessTokenSecret = "8PT5lmK8OR67bSr1up2YwJLSMolpXi0mHGnJDc9fOVEcL";

        public string Title { get; set; }
        public string Image { get; set; }

        private int UserAuthentication()
        {
            // Set user credentials before posting to Twitter
            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            var authenticatedUser = User.GetAuthenticatedUser();

            if (authenticatedUser == null)
            {
                Console.WriteLine("Twitter authentication failed. Check credentials and try again.");
                return 0;
            }

            return 1;
        }

        // Here is where our hashtags are stored for
        // the tweets we send out
        // We've set it so that it will randomly
        // choose 1 from this pool of 10
        // hashtags

        public string GetHashtags()
        {

            string h1 = "#MAGA";
            string h2 = "#TrumpTrain";
            string h3 = "#MakeAmericaGreatAgain";
            string h4 = "#sjw";
            string h5 = "#SocialJustice";
            string h6 = "#issues";
            string h7 = "#resist";
            string h8 = "#woke";
            string h9 = "#BlackLivesMatter";
            string h10 = "#altright";

            string[] selectableHashtags = new string[10] { h1, h2, h3, h4, h5, h6, h7, h8, h9, h10 };

            Random randomizeHashtag = new Random();

            string randomHashtag = selectableHashtags[randomizeHashtag.Next(0, selectableHashtags.Length)];
            return randomHashtag;
        }

        // We'll pass in the scraped images/memes so
        // this method can build our tweet and then
        // call the PublishTweet method

        public void PublishTweet(string title, string image)
        {
            // Activate automatic ratelimit tracking

            RateLimit.RateLimitTrackerMode = RateLimitTrackerMode.TrackAndAwait;
            
            // Here we create our timer object and
            // call our method to randomize posting
            // tweets            

            string hashtag = GetHashtags();

            // Authenticate user before proceeding
            int userAuthentication = UserAuthentication();
            if (userAuthentication == 0)
            {
                Console.WriteLine("Failed to publish tweet.");
            }
            else
            {
                if (!image.Contains("gif"))
                {
                    WebClient wc = new WebClient();
                    try
                    {
                        byte[] bytes = wc.DownloadData(image);
                        var media = Upload.UploadImage(bytes);
                        var tweets = Tweet.PublishTweet(title + " " + hashtag, new PublishTweetOptionalParameters
                        {
                            Medias = { media }
                        });

                        Console.WriteLine("Tweet posted!");
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Image missing!");
                        NewTweetsAsync();
                    }
                    
                }
                
            }
        }

        public async void NewTweetsAsync()
        {
            // Search DB for new images
            // publish tweet to twitter
            var db = new DbConnection();
            int randomMin = Timer.RandomizeTwitterTimer();
            List<Twitter> getTweets = db.GetTweets();

            foreach (var tweet in getTweets)
            {
                // Shortens title to only 140 characters.
                // But need to fix it where the title can make some sense.
                int maxLength = Math.Min(tweet.Title.Length, 100);
                tweet.Title = tweet.Title.Substring(0, maxLength);

                Console.WriteLine(tweet.Title);
                Console.WriteLine(tweet.Image);
                PublishTweet(tweet.Title, tweet.Image);
                db.HasBeenPosted(tweet.Image);
            }

            Console.WriteLine("Waiting " + randomMin + " minutes for next tweet! " + DateTime.Now);
            await Task.Delay(TimeSpan.FromMinutes(randomMin));
            Task.WaitAll();
            await Task.Run(() =>
            {
                NewTweetsAsync();
            });
            
        }

    }
}
