using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TweetCrawler.Entities
{
    public class TwtUser : BaseEntity
    {
        public bool IsDeleted { get; set; }

        public string ScreenName { get; set; }
    }
}
