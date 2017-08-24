using System;
using System.Net;
using Newtonsoft.Json;
using TrumpTweeter.Json;
using System.Threading.Tasks;

namespace TrumpTweeter
{
    public class Reddit
    {
        private string Url = @"https://www.reddit.com/r/The_Donald/new/" + ".json";

        // We'll use this method to connect to the
        // r/The_Donald subreddit and then call the
        // ScrapeImage method

        public async void ConnectToReddit()
        {
            int randomMin = BTimer.RandomizeTwitterTimer();

            var redditConnectionJson = new WebClient().DownloadString(Url);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(redditConnectionJson);

            CheckForImages(rootObject); 
            Console.WriteLine("Waiting " + randomMin + " minutes for next scrape " + DateTime.Now);

            await Task.Delay(TimeSpan.FromMinutes(randomMin));
            await Task.Run(() =>
            {
                ConnectToReddit();
            });
            
        }

        public async void StartRedditAsync()
        {
             await Task.Run(() =>
          {
              ConnectToReddit();
          });
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

                    Insert title and image to database
                    var dbConnection = new DbConnection();
                    dbConnection.Insert(title, image);
                    
                }
            }

            // Here we create our timer object and
            // call our method to randomize scraping

            ATimer.RedditTimer();            
        } 
    }
}
