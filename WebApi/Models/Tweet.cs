
namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Tweet
    {
        public int TweetID { get; set; }
        public string Created_at { get; set; }
        public string Text { get; set; }
        public Nullable<int> favourite_count { get; set; }
        public string lang { get; set; }
        public string place { get; set; }
        public Nullable<int> retweet_count { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
