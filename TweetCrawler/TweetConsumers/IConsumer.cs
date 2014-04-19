using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetCrawler.TweetConsumers
{
    public interface IConsumer
    {
        void ProccessTweets(IEnumerable<Tweet> tweets);

        IEnumerable<string> GetTwitterUsers();
    }
}
