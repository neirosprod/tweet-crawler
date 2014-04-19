using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetCrawler.Crawlers
{
    public interface ICrawler
    {
        IEnumerable<Tweet> GetTweets(string page);
    }
}
