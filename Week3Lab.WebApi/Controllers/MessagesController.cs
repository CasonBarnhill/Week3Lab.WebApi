using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;

namespace Week3Lab.WebApi.Controllers
{
    public class MessagesController : ApiController
    {
        public IHttpActionResult CreateMessage(Message message)
        {

            var allMessages = GetMessages();
            if (allMessages.Any())
                message.Id = allMessages.Max(x => x.Id) + 1;
            else
                message.Id = 1;
            
            allMessages.Add(message);
            SaveMessages(allMessages);
            return Ok(message);
        }
       public IHttpActionResult GetAllMessages()
        {
            var messages = GetMessages();
            return Ok(messages);
        }
         

        //code that Daniel posted to retrieve input from users
        private List<Message> GetMessages()
        {
            //Retrieve out of the cache the current posts.
            MemoryCache memoryCache = MemoryCache.Default;
            var messages = (List<Message>)memoryCache.Get("messages");

            if (messages == null)
            {
                messages = new List<Message>();
                messages.Add(new Message {Author= "Cason", Body= "Hello", Id=1, DatePosted= DateTime.Now });
                memoryCache.Set("messages", messages, DateTimeOffset.Now.AddSeconds(10));
            }

            return messages;
        }
        private void SaveMessages(List<Message> posts)
        {
            //put the list of posts back in to the cache.
            MemoryCache memoryCache = MemoryCache.Default;
            memoryCache.Set("messages", posts, DateTimeOffset.Now.AddSeconds(10));

        }

    }
}
