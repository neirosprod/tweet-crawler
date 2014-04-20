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
    /// Crawler for the new twitter profile
    /// </summary>
    public class Crawler2 : ICrawler
    {
        public IEnumerable<Tweet> GetTweets(string page)
        {
            var html = new HtmlDocument();
            html.LoadHtml(page);

            var document = html.DocumentNode;
            var tweetNodes = document.QuerySelectorAll(".StreamItem").ToList();

            foreach (var tweetNode in tweetNodes)
            {
                var tweetTime = GetDate(tweetNode);

                //images
                var mediaNodes = tweetNode.QuerySelectorAll(".media-thumbnail");
                var media = mediaNodes
                    .Select(x => x.Attributes["data-source-url"] != null
                                        ? x.Attributes["data-source-url"].Value
                                        : x.Attributes["data-url"].Value)
                    .ToList();

                //user id
                var userNode = tweetNode.QuerySelector(".js-user-profile-link");
                var userId = (userNode != null) ? userNode.Attributes["data-user-id"].Value : null;

                yield return new Tweet()
                {
                    What = tweetNode.QuerySelector(".ProfileTweet-text").InnerText,
                    Who = tweetNode.QuerySelector(".ProfileTweet-fullname").InnerText,
                    WhoId = userId,
                    Link = tweetNode.QuerySelector(".ProfileTweet-timestamp").Attributes["href"].Value,
                    When = tweetTime.ToString(),
                    StatusId = Regex.Match(tweetNode.QuerySelector(".ProfileTweet-timestamp").Attributes["href"].Value, @"^[\s\S]+/([\d]+)$").Groups[1].Value,
                    Media = media
                };

            }
        }

        protected virtual DateTime GetDate(HtmlNode tweetNode)
        {
            return new DateTime(new DateTime(1970, 1, 1, 0, 0, 0).Ticks + long.Parse(tweetNode.QuerySelector(".js-short-timestamp").Attributes["data-time"].Value) * 10000 * 1000);
        }
    }
}
