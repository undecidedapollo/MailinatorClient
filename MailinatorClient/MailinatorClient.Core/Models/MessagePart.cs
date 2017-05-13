using System;
using System.Collections.Generic;
using System.Text;

namespace MailinatorClient.Core.Models
{
    public class MessagePart
    {
        public Dictionary<string, string> Headers { get; set; }

        public string Body { get; set; }

    }
}
