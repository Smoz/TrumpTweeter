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
        public string GetHashtags()
        {

            string h1 = "#MAGA";
            string h2 = "#TrumpTrain";
            string h3 = "#MakeAmericaGreatAgain";
            string h4 = "#Trump";

            string[] selectableHashtags = new string[4] { h1, h2, h3, h4 };

            Random randomizeHashtag = new Random();

            string randomHashtag = selectableHashtags[randomizeHashtag.Next(0, selectableHashtags.Length)];
            return randomHashtag;
        }


        // We'll pass in the scraped images/memes so
        // this method can build our tweet and then
        // call the PublishTweet method

        public void PublishTweet(string title, string image)
        {

            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(image);
            var media = Upload.UploadImage(bytes);
            string hashtag = GetHashtags();

            var tweet = Tweet.PublishTweet(title + " " + hashtag, new PublishTweetOptionalParameters
            {
                Medias = { media }
            });
        }

    }
}
