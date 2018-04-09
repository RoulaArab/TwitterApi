
namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;

    public partial class User
    {
        public User()
        {
            this.Tweets = new HashSet<Tweet>();
        }

        public int UserID { get; set; }
        public string Created_date { get; set; }
        public string description { get; set; }
        public Nullable<int> favourites_count { get; set; }
        public Nullable<int> followers_count { get; set; }
        public Nullable<int> friends_count { get; set; }
        public string lang { get; set; }
        public string location { get; set; }
        public string Name { get; set; }
        public string screen_name { get; set; }
        public Nullable<int> status_count { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}
