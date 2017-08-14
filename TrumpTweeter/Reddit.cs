using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TrumpTweeter
{
    public class MediaEmbed
    {
        public string content { get; set; }
        public int? width { get; set; }
        public bool? scrolling { get; set; }
        public int? height { get; set; }
    }

    public class Oembed
    {
        public string provider_url { get; set; }
        public string version { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public int thumbnail_width { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string html { get; set; }
        public string author_name { get; set; }
        public string provider_name { get; set; }
        public string thumbnail_url { get; set; }
        public int thumbnail_height { get; set; }
        public string author_url { get; set; }
        public string description { get; set; }
    }

    public class SecureMedia
    {
        public Oembed oembed { get; set; }
        public string type { get; set; }
    }

    public class Oembed2
    {
        public string provider_url { get; set; }
        public string version { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public int thumbnail_width { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string html { get; set; }
        public string author_name { get; set; }
        public string provider_name { get; set; }
        public string thumbnail_url { get; set; }
        public int thumbnail_height { get; set; }
        public string author_url { get; set; }
        public string description { get; set; }
    }

    public class Media
    {
        public Oembed2 oembed { get; set; }
        public string type { get; set; }
    }

    public class Source
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Resolution
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Variants
    {
    }

    public class Image
    {
        public Source source { get; set; }
        public List<Resolution> resolutions { get; set; }
        public Variants variants { get; set; }
        public string id { get; set; }
    }

    public class Preview
    {
        public List<Image> images { get; set; }
        public bool enabled { get; set; }
    }

    public class SecureMediaEmbed
    {
        public string content { get; set; }
        public int? width { get; set; }
        public bool? scrolling { get; set; }
        public int? height { get; set; }
    }

    public class Data2
    {
        public string domain { get; set; }
        public object approved_at_utc { get; set; }
        public object banned_by { get; set; }
        public MediaEmbed media_embed { get; set; }
        public int? thumbnail_width { get; set; }
        public string subreddit { get; set; }
        public string selftext_html { get; set; }
        public string selftext { get; set; }
        public object likes { get; set; }
        public object suggested_sort { get; set; }
        public List<object> user_reports { get; set; }
        public SecureMedia secure_media { get; set; }
        public string link_flair_text { get; set; }
        public string id { get; set; }
        public object banned_at_utc { get; set; }
        public object view_count { get; set; }
        public bool archived { get; set; }
        public bool clicked { get; set; }
        public object report_reasons { get; set; }
        public string title { get; set; }
        public Media media { get; set; }
        public List<object> mod_reports { get; set; }
        public bool can_mod_post { get; set; }
        public string author_flair_text { get; set; }
        public int score { get; set; }
        public object approved_by { get; set; }
        public bool over_18 { get; set; }
        public bool hidden { get; set; }
        public Preview preview { get; set; }
        public string thumbnail { get; set; }
        public string subreddit_id { get; set; }
        public bool edited { get; set; }
        public string link_flair_css_class { get; set; }
        public string author_flair_css_class { get; set; }
        public bool contest_mode { get; set; }
        public int gilded { get; set; }
        public int downs { get; set; }
        public bool brand_safe { get; set; }
        public SecureMediaEmbed secure_media_embed { get; set; }
        public bool saved { get; set; }
        public object removal_reason { get; set; }
        public string post_hint { get; set; }
        public bool stickied { get; set; }
        public bool can_gild { get; set; }
        public int? thumbnail_height { get; set; }
        public string parent_whitelist_status { get; set; }
        public string name { get; set; }
        public bool spoiler { get; set; }
        public string permalink { get; set; }
        public string subreddit_type { get; set; }
        public bool locked { get; set; }
        public bool hide_score { get; set; }
        public double created { get; set; }
        public string url { get; set; }
        public string whitelist_status { get; set; }
        public bool quarantine { get; set; }
        public string author { get; set; }
        public double created_utc { get; set; }
        public string subreddit_name_prefixed { get; set; }
        public int ups { get; set; }
        public int num_comments { get; set; }
        public bool is_self { get; set; }
        public bool visited { get; set; }
        public object num_reports { get; set; }
        public bool is_video { get; set; }
        public object distinguished { get; set; }
    }

    public class Child
    {
        public string kind { get; set; }
        public Data2 data { get; set; }
    }

    public class Data
    {
        public string modhash { get; set; }
        public List<Child> children { get; set; }
        public string after { get; set; }
        public object before { get; set; }
    }

    public class RootObject
    {
        public string kind { get; set; }
        public Data data { get; set; }
    }

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
            //ScrapeImage(doc);
        }

        // We'll use this method to check if there are
        // any images/memes to upload by checking the
        // domain of the site on the listing
        // If a site is detected then we get the url
        // of the linked image and proceed to call
        // our ScrapeImage method

        static void CheckForImages(RootObject rootObject)
        {
            var jpg = "jpg";
            var png = "png";
            var gif = "gif";

            foreach (var item in rootObject.data.children)
            {
                if (item.data.url.Contains(jpg) | item.data.url.Contains(png) | item.data.url.Contains(gif))
                {
                    Console.WriteLine("Gotcha Bitch! " + item.data.url);

                }
            }
        }      

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
