using System.Collections.Generic;

namespace TweetCrawler.Entities
{
    public class Tweet : BaseEntity
    {
        public Tweet()
        {
            Tags = new List<TagSummary>();
            Media = new List<string>();
        }

        /// <summary>
        /// Twitter user name ex: ZacEfron
        /// </summary>
        public string Who { get; set; }

        /// <summary>
        /// Twitter user link ex: "https://twitter.com/ZacEfron"
        /// </summary>
        public string WhoLink { get; set; }

        /// <summary>
        /// user id in twitter
        /// </summary>
        public string WhoId { get; set; }
        
        /// <summary>
        /// List of the link of all media elements in the tweet (all images and videos)
        /// </summary>
        public List<string> Media { get; set; }

        /// <summary>
        /// tweet content
        /// </summary>
        public string What { get; set; }

        /// <summary>
        /// Tweet date
        /// </summary>
        public string When { get; set; }

        /// <summary>
        /// tweet id inside Twitter
        /// </summary>
        public string StatusId { get; set; }

        /// <summary>
        /// tweet link ex: https://twitter.com/ZacEfron/status/statusid
        /// </summary>
        public string Link { get; set; }


        public string Where { get; set; }

        public string Description { get; set; }

        public List<TagSummary> Tags { get; set; }

        
    }

    public class TagSummary
    {
        /* Tag summary fields */
    }
}
