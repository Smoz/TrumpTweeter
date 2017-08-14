using Tweetinvi;

namespace TrumpTweeter
{
    public class Twitter
    {
        // We'll pass in the scraped images/memes so
        // this method can build our tweet and then
        // call the PublishTweet method


        public void PublishTweet()
        {
            Tweet.PublishTweet("Hello world!");
        }
    }
}
