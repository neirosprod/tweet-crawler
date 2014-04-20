using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetCrawler.Entities;

namespace TweetCrawler.Crawlers
{
    public interface ICrawler
    {
        IEnumerable<Tweet> GetTweets(string page);
    }
}
