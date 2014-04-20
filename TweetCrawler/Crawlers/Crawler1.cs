using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using TweetCrawler.Entities;

namespace TweetCrawler.Crawlers
{
    /// <summary>
    /// Crawler for the old twitter profile
    /// </summary>
    public class Crawler1 : ICrawler
    {
        public IEnumerable<Tweet> GetTweets(string page)
        {
            var html = new HtmlDocument();
            html.LoadHtml(page);

            var document = html.DocumentNode;
            var tweetNodes = document.QuerySelectorAll(".js-stream-item").ToList();

            foreach (var tweetNode in tweetNodes)
            {
                var tweetTime = new DateTime(new DateTime(1970, 1, 1, 0, 0, 0).Ticks + long.Parse(tweetNode.QuerySelector("._timestamp").Attributes["data-time-ms"].Value) * 10000);

                //image
                var imgNode = tweetNode.QuerySelector(".is-preview");
                var imgUrl = (imgNode != null) ? imgNode.Attributes["data-url"].Value : null;
                var images = new List<string> { imgUrl };

                //user id
                var userNode = tweetNode.QuerySelector(".js-user-profile-link");
                var userId = (userNode != null) ? userNode.Attributes["data-user-id"].Value : null;

                yield return new Tweet()
                {
                    What = tweetNode.QuerySelector(".tweet-text").InnerText,
                    Who = tweetNode.QuerySelector(".fullname").InnerText,
                    WhoId = userId,
                    Link = tweetNode.QuerySelector(".tweet-timestamp").Attributes["href"].Value,
                    When = tweetTime.ToString(),
                    StatusId =
                        Regex.Match(tweetNode.QuerySelector(".tweet-timestamp").Attributes["href"].Value,
                                    @"^[\s\S]+/([\d]+)$").Groups[1].Value,
                    Media = images

                };

            }
        }

    }
}
