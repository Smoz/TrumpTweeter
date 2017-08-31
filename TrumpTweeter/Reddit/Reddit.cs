using System;
using System.Net;
using Newtonsoft.Json;
using TrumpTweeter.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TrumpTweeter
{
    public class Reddit
    {
        private string Url = @"https://www.reddit.com/r/The_Donald/new/" + ".json";

        public string Title { get; set; }
        public string Image { get; set; }

        // We'll use this method to connect to the
        // r/The_Donald subreddit and then call the
        // ScrapeImage method

        public async void ConnectToReddit()
        {
            int randomMin = Timer.RandomizeRedditTimer();

            var redditConnectionJson = new WebClient().DownloadString(Url);
            RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(redditConnectionJson);

            CheckForImages(rootObject);
            Console.WriteLine("Waiting " + randomMin + " minutes for next scrape " + DateTime.Now);

            await Task.Delay(TimeSpan.FromMinutes(randomMin));
            Task.WaitAll();
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
            List<Reddit> getRedditPosts = new List<Reddit>();
            var db = new DbConnection();

            var jpg = "jpg";
            var png = "png";
            var gif = "gif";
            
            foreach (var item in rootObject.data.children)
            {
                if (item.data.url.Contains(jpg) | item.data.url.Contains(png) | item.data.url.Contains(gif))
                {
                    Title = item.data.title;
                    Image = item.data.url;

                    var redditPost = new Reddit
                    {
                        Title = item.data.title,
                        Image = item.data.url
                    };

                    db.CheckDbForDuplicates(redditPost, Title, Image);
                    getRedditPosts.Add(redditPost);
                }

                
            }          
        } 
    }
}
