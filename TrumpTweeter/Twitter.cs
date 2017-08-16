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
