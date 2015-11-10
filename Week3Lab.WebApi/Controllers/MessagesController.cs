using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Week3Lab.WebApi.Controllers
{
    public class MessagesController : ApiController
    {
        IHttpActionResult GetMessages()
        {
            var messages = GetMessages();
            return Ok(messages);
        }
         IHttpActionResult SaveMessages()
        {
            var messages = SaveMessages();
            return Ok(messages);
        }

        //code that Daniel posted to retrieve input from users
        private List<Post> GetPosts()
        {
            //Retrieve out of the cache the current posts.
            MemoryCache memoryCache = MemoryCache.Default;
            var posts = (List<Post>)memoryCache.Get("BLAH");

            if (posts == null)
            {
                posts = new List<Post>();
                memoryCache.Set("BLAH", posts, DateTimeOffset.Now.AddSeconds(10));
            }

            return posts;
        }
        private void SavePosts(List<Post> posts)
        {
            //put the list of posts back in to the cache.
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set("BLAH", posts, DateTimeOffset.Now.AddSeconds(10));

        }
        //var addMessage = new Post($"api/posts/{info.addMessage}, Method.GET");
        //Post author = .Execute<Post>().Data;
        // private static object info;



        // public IEnumerable<Post> AddPost()
        //{
        //    return "";
        // }
        // public IHttpActionResult DeletePost(int id)
        // {
        //     var deletePost = posts.First(p => p);
        //    posts.Remove(deletePost);
        //   return Ok();
        // }

    }
}
