using MailinatorClient.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailinatorClient.ConsoleTests
{
    class Program
    {
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json"))
                .Build();
        }

        static void Main(string[] args)
        {
            var config = GetConfiguration();

            var key = config["apiKey"];

            var client = new StandardMailinatorClient(key);
            Task.Run(async () =>
            {
                var mail = await client.GetInbox("test");

                Console.WriteLine($"Recieved {mail.Messages.Count} messages.");

                for(var i = 0; i < 5 && i < mail.Messages.Count; i++)
                {
                    Console.WriteLine($"Downloading message from {mail.Messages[i].From}");

                    var message = await client.GetFullMessage(mail.Messages[i]);

                    Console.WriteLine($"Body Contents:");
                    Console.WriteLine(message.Data.Parts.FirstOrDefault()?.Body);
                }

                var privateMail = await client.GetInbox("test", true);

                Console.WriteLine($"Recieved {privateMail.Messages.Count} messages.");

                for (var i = 0; i < 5 && i < privateMail.Messages.Count; i++)
                {
                    Console.WriteLine($"Downloading message from {privateMail.Messages[i].From}");

                    var message = await client.GetFullMessage(privateMail.Messages[i]);

                    Console.WriteLine($"Body Contents:");
                    Console.WriteLine(message.Data.Parts.FirstOrDefault()?.Body);
                }


                var savedMail = await client.GetSavedInbox();

                Console.WriteLine($"Recieved {savedMail.Messages.Count} saved messages.");

                for (var i = 0; i < 5 && i < savedMail.Messages.Count; i++)
                {
                    Console.WriteLine($"Downloading message from {savedMail.Messages[i].From}");

                    var message = await client.GetFullMessage(mail.Messages[i]);

                    Console.WriteLine($"Body Contents:");
                    Console.WriteLine(message.Data.Parts.FirstOrDefault()?.Body);
                }
            }).GetAwaiter().GetResult();

            Console.ReadKey();
          
        }
    }
}
