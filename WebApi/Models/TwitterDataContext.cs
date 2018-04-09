using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Models
{
    public class TwitterDataContext : DbContext
    {
        public TwitterDataContext()
            : base("TwitterConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> User { get; set; }

        public DbSet<Tweet> Tweet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tweet>()
            .HasRequired<User>(s => s.User)
            .WithMany(g => g.Tweets)
            .HasForeignKey(s => s.UserID);

        }
        public static TwitterDataContext Create()
        {

            return new TwitterDataContext();
        }
    }
}