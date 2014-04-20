using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetCrawler.Entities;

namespace TweetCrawler.TweetConsumers
{
    public class ConsoleConsumer: IConsumer
    {
        public void ProccessTweets(IEnumerable<Tweet> tweets)
        {
            foreach (var tweet in tweets)
            {
                Console.WriteLine("{0}-{1}-medias:{{{2}}}", tweet.Who, tweet.When, string.Join(",", tweet.Media));
            }
            Console.WriteLine("********************************************************");
        }

        public IEnumerable<string> GetTwitterUsers()
        {
            return new List<string>()
                {
                    "SolovievDmitry"
                    ,"xbutteff"
                };

        }
    }
}
