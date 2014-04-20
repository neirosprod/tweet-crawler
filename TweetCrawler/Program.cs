using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TweetCrawler.TweetConsumers;

namespace TweetCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************************************************");

            //var crawlerController = new CrawlerController(new ConsoleConsumer());
            var crawlerController = new CrawlerController(new MongoDbConsumer());

            try
            {
                crawlerController.Crawl();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
