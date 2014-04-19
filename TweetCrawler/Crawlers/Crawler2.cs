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
    /// Crawler for the new twitter profile
    /// </summary>
    public class Crawler2: ICrawler
    {
        public IEnumerable<Tweet> GetTweets(string page)
        {
            throw new NotImplementedException();
            
        }

        protected virtual DateTime GetDate(HtmlNode tweetNode)
        {
            return new DateTime(new DateTime(1970, 1, 1, 0, 0, 0).Ticks + long.Parse(tweetNode.QuerySelector(".js-short-timestamp").Attributes["data-time"].Value) * 10000 * 1000);
        }
    }
}
