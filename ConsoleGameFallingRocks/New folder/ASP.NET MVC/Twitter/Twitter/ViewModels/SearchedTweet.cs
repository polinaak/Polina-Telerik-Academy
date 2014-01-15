using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Twitter.Models;

namespace Twitter.ViewModels
{
    public class SearchedTweet
    {
        public static Expression<Func<Tweet, SearchedTweet>> FromTweet
        {
            get
            {
                return tweet => new SearchedTweet
                {
                   Id = tweet.TweetId,
                   Message = tweet.Message
                };
            }
        }

        public int Id { get; set; }

        public string Message { get; set; }
    }
}