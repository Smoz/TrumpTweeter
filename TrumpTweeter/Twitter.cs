using Tweetinvi;
using System.IO;
using System;
using Tweetinvi.Parameters;
using Tweetinvi.Models;
using System.Collections.Generic;
using System.Net;


namespace TrumpTweeter
{
    public class Twitter
    {
        private const string consumerKey = "2J78Z9plJmSjpqNEazBPUqWa8";
        private const string consumerSecret = "t20mxNim4PFDHLfD2EmlLJqYC2ypPfvys5quSXP9RFWhkWMFj9";
        private const string accessToken = "895911288781639680-SDjYnqMb9zERLaed8WwEtv323yqmmoz";
        private const string accessTokenSecret = "8PT5lmK8OR67bSr1up2YwJLSMolpXi0mHGnJDc9fOVEcL";

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
            string hashtag = GetHashtags();

            // Authenticate user before proceeding

            int userAuthentication = UserAuthentication();
            if (userAuthentication == 0)
            {
                Console.WriteLine("Failed to publish tweet.");
            }
            else
            {
                WebClient wc = new WebClient();
                try
                {
                    byte[] bytes = wc.DownloadData(image);
                    var media = Upload.UploadImage(bytes);
                    var tweet = Tweet.PublishTweet(title + " " + hashtag, new PublishTweetOptionalParameters
                    {
                        Medias = { media }
                    });
                }
                catch (ConnectionAbortedException e)
                {
                    Console.WriteLine("ConnectionAbortedException: {0}", e.Message);
                    PublishTweet(title, image);
                }
            }
                      
        }

    }
}
