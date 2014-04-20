using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TweetCrawler.Entities;

namespace TweetCrawler.TweetConsumers
{
    public class MongoDbConsumer : IConsumer
    {
        private readonly MongoDatabase _mongoDatabase;

        #region DB settings
        private const string _mongoCnnStr = "mongodb://localhost";
        private const string _dbName = "TwitterListener";
        private readonly WriteConcern _concern = new WriteConcern { Journal = true, W = 1 };
        #endregion

        public MongoDbConsumer()
        {
            _mongoDatabase = new MongoClient(_mongoCnnStr).GetServer().GetDatabase(_dbName);

        }
        
        
        public void ProccessTweets(IEnumerable<Tweet> tweets)
        {
            var tweetCollection = _mongoDatabase.GetCollection<Tweet>("Tweet", _concern);

            var tweetList = tweets.ToList();

            Console.WriteLine("bulk inserting " + tweetList.Count);
            tweetCollection.InsertBatch(tweetList);
            Console.WriteLine("insert done");
        }


        public IEnumerable<string> GetTwitterUsers()
        {
            var users = _mongoDatabase.GetCollection<TwtUser>("TwtUser", _concern)
                                      .AsQueryable()
                                      .Where(x => !x.IsDeleted)
                                      .Select(u => u.ScreenName);


            return users;
        }
    }

   
}
