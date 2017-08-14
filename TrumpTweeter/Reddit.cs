using HtmlAgilityPack;
using System;
using System.Linq;

namespace TrumpTweeter
{
    public class Reddit
    {

        // We'll use this method to connect to the
        // r/The_Donald subreddit and then call the
        // ScrapeImage method
        public void ConnectToReddit()
        {
            string url = Globals.url;
            HtmlDocument doc = new HtmlWeb().Load(url);
            ScrapeImage(doc);
        }

        // We'll use this method to scrape images/memes
        // from r/The_Donald and then call the CreateTweet
        // method

        static void ScrapeImage(HtmlDocument doc)
        {
            var imagesAndMemesUrl = doc.DocumentNode.SelectNodes("//p[@class='title']/a").ToArray();

            foreach (var imageAndMemeUrl in imagesAndMemesUrl)
            {
                Console.WriteLine(imageAndMemeUrl.InnerText);
                Console.WriteLine(imageAndMemeUrl.Attributes["href"].Value);
                Console.WriteLine();
            }
            Console.ReadKey();

            //var twitter = new Twitter();
            //twitter.PublishTweet();
        }
    }
}
