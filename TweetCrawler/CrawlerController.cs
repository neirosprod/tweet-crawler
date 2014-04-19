using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using TweetCrawler.Crawlers;
using TweetCrawler.TweetConsumers;

namespace TweetCrawler
{
    public class CrawlerController
    {
        private readonly IConsumer _consumer;

        public CrawlerController(IConsumer consumer)
        {
            _consumer = consumer;
        }

        public void Crawl()
        {
            Crawl(_consumer.GetTwitterUsers());
        }

        public void Crawl(IEnumerable<string> twitterUsers)
        {
            foreach (var twitterUser in twitterUsers)
            {
                try
                {
                    var page = GetPage(twitterUser);

                    var crawler = GetCrawler(page);

                    var tweets = crawler.GetTweets(page);

                    _consumer.ProccessTweets(tweets);

                    Thread.Sleep(15000);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Attempt failed with user: {0}. Error: {1}", twitterUser, ex.Message);
                    Thread.Sleep(10000);
                }
            }
        }



        /// <summary>
        /// Identifies the type of twitter page (1: the old format or 2: the new format).
        /// Return the appropiate crawler.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private ICrawler GetCrawler(string page)
        {
            //old format by default
            ICrawler crawler = new Crawler1();

            //find if the twitter page matches the new format
            var html = new HtmlDocument();
            html.LoadHtml(page);
            var nodes = html.DocumentNode.QuerySelectorAll(".GridTimeline").ToList();

            if (nodes.Any())
                crawler = new Crawler2();

            return crawler;
        }


        public string GetPage(string url)
        {
            return GetPage(url, Encoding.UTF8);
        }


        public string GetPage(string url, Encoding encoding)
        {
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            webReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0";
            webReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            return (new StreamReader(webReq.GetResponse().GetResponseStream(), encoding)).ReadToEnd();
        }
    }
}
