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
            CheckForImages(doc);
            //ScrapeImage(doc);
        }

        // We'll use this method to check if there are
        // any images/memes to upload by checking the
        // domain of the site on the listing
        // If a site is detected then we get the url
        // of the linked image and proceed to call
        // our ScrapeImage method

        static void CheckForImages(HtmlDocument doc)
        {
            string s1 = "i.redd.it";
            string s2 = "i.imgur.com";

            var spans = doc.DocumentNode.SelectNodes("//span[@class='domain']").ToArray();
            // Check if images are present

            foreach (var span in spans)
            {
                string getImageAndMemeSpanText = span.InnerText;

                bool iReddit = getImageAndMemeSpanText.Contains(s1);
                bool imgur = getImageAndMemeSpanText.Contains(s2);

                if (iReddit || imgur == true)
                {
                    Console.WriteLine("Target image site detected!");

                    // If the an image site is detected then we would call
                    // ScrapeImage to scrape that image.
                    // So we add the domain to a local variable and pass
                    // that variable to our scraper

                    // ScrapeImage(doc);
                }
                else if (iReddit && imgur == false)
                {
                    Console.WriteLine("Sorry, no new images/memes right now...boop boop..boooop. :((");
                }

            }

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
