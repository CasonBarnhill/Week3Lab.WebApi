using System;

namespace Week3Lab.WebApi.Controllers
{
    public class Message
    {
        internal DateTime DatePosted;

        public string Author { get;  set; }
        public string Body { get;  set; }
        public int Id { get;  set; }
    }

}