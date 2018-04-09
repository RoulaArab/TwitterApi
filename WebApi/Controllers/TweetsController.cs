using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TweetsController : ApiController
    {
        private TwitterDataContext db = new TwitterDataContext();

        // GET: api/Tweets
        public IQueryable<Tweet> GetTweet()
        {
            return db.Tweet;
        }

        // GET: api/Tweets/5
        [ResponseType(typeof(Tweet))]
        public IHttpActionResult GetTweet(int id)
        {
            Tweet tweet = db.Tweet.Find(id);
            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(tweet);
        }

        // PUT: api/Tweets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTweet(int id, Tweet tweet)
        {

            if (id != tweet.TweetID)
            {
                return BadRequest();
            }

            db.Entry(tweet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TweetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tweets
        [ResponseType(typeof(Tweet))]
        public IHttpActionResult PostTweet(Tweet tweet)
        {

            db.Tweet.Add(tweet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tweet.TweetID }, tweet);
        }

        // DELETE: api/Tweets/5
        [ResponseType(typeof(Tweet))]
        public IHttpActionResult DeleteTweet(int id)
        {
            Tweet tweet = db.Tweet.Find(id);
            if (tweet == null)
            {
                return NotFound();
            }

            db.Tweet.Remove(tweet);
            db.SaveChanges();

            return Ok(tweet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TweetExists(int id)
        {
            return db.Tweet.Count(e => e.TweetID == id) > 0;
        }
    }
}