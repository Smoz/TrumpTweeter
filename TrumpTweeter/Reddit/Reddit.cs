using System;
using System.Net;
using Newtonsoft.Json;
using TrumpTweeter.Json;


namespace TrumpTweeter
{
    public class Reddit
    {

        // We'll use this method to connect to the
        // r/The_Donald subreddit and then call the
        // ScrapeImage method

        public void ConnectToReddit()
        {
            var redditConnectionJson = new WebClient().DownloadString(Globals.url);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(redditConnectionJson);
            
            CheckForImages(rootObject);
            
        }

        // We'll use this method to check if there are
        // any images/memes to upload by checking the
        // domain of the site on the listing
        // If a site is detected then we get the url
        // of the linked image and proceed to call
        // our ScrapeImage method

        public void CheckForImages(RootObject rootObject)
        {     
            var jpg = "jpg";
            var png = "png";
            var gif = "gif";

            foreach (var item in rootObject.data.children)
            {
                if (item.data.url.Contains(jpg) | item.data.url.Contains(png) | item.data.url.Contains(gif))
                {
                    Console.WriteLine(item.data.title + " " + item.data.url);
                    Console.WriteLine();
                                        
                    var title = item.data.title;
                    var image = item.data.url;

                    ConnectToDatabase(title, image);

                    var twitter = new Twitter();
                    twitter.PublishTweet(title, image);
                    
                }
                
            } 

            // Here we create our timer object and
            // call our method to randomize scraping
            // and posting tweets

            var timer = new ATimer();
            ATimer.RedditTimer();            
        }
        
        public void ConnectToDatabase(string title, string image)
        {
            // Here we create our database connection
            // object so we can add our titles and image
            // urls to a mysql database for further
            // processing and use

            DbConnection dbConnection = new DbConnection();
            dbConnection.ConnectingToDb(title, image);
        }
                
    }
}
