using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace TweetCrawler.Crawlers
{
    /// <summary>
    /// Crawler for the old twitter profile
    /// </summary>
    public class Crawler1 : ICrawler
    {
        public IEnumerable<Tweet> GetTweets(string page)
        {
            throw  new NotImplementedException();
        }

    }
}
