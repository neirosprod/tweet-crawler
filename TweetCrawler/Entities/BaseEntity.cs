using MongoDB.Bson;

namespace TweetCrawler.Entities
{
    public class BaseEntity
    {
        public ObjectId Id { get; set; }
    }
}
