using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailinatorClient.Core.Models
{
    public class Message
    {
        public string FromFull { get; set; }
        public string Subject { get; set; }
        public int RequestId { get; set; }
        public string From { get; set; }
        [JsonProperty("origfrom")]
        public string OriginalFrom { get; set; }
        public string To { get; set; }
        public string Id { get; set; }
        public long Time { get; set; }
        public int SecondsAgo { get; set; }
        public IList<MessagePart> Parts { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}
