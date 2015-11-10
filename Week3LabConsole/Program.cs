using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3LabConsole
{
    public class Message
    {
        public string Author { get; set; }
        public string Body { get; set; }
        public int Id { get; set; }
        public DateTime DatePosted { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                Message msg = new Message();
                Console.WriteLine("What's your name?");
                msg.Author = Console.ReadLine();
                Console.WriteLine("Whats on your mind?");
                msg.Body = Console.ReadLine();
                msg.DatePosted = DateTime.Now;


                var client = new RestClient("http://localhost:64244/");
                var request = new RestRequest("api/messages", Method.POST)
                { RequestFormat = DataFormat.Json };
                request.AddJsonBody(msg);
                var response = client.Execute<Message>(request);


            }

            Console.ReadLine();
        }

       
    }
}
