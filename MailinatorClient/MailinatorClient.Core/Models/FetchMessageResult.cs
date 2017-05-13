using System;
using System.Collections.Generic;
using System.Text;

namespace MailinatorClient.Core.Models
{
    public class FetchMessageResult
    {
        public Message Data { get; set; }
        public int ApiEmailFetchesLeft { get; set; }
    }
}
