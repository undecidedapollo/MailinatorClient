using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MailinatorClient.Core.Extensions;

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
        [JsonProperty("seconds_ago")]
        public int SecondsAgo { get; set; }
        public IList<MessagePart> Parts { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public bool IsPrivateMessage { get; set; }

        public string GetHtmlContentAsString()
        {
            return this.GetContentAsString("text/html");
        }

        public MessagePart GetHtmlContent()
        {
            return this.GetContent("text/html");
        }

        public string GetTextContentAsString()
        {
            return this.GetContentAsString("text/plain");
        }

        public MessagePart GetTextContent()
        {
            return this.GetContent("text/plain");
        }

        public MessagePart GetContent(string contentType)
        {
            return this?.Parts?.FirstOrDefault(x => x.Headers.Any(y => y.Key == "content-type" && y.Value.Contains(contentType)));
        }

        public string GetContentAsString(string contentType)
        {
            return this.GetContent(contentType)?.Body;
        }

        public IEnumerable<Attachment> GetAttachments()
        {
            return this?.Parts?.Where(x => x.Headers.Any(y => y.Key.Contains("attachment")))?.Select(x => x?.ToAttachment());
        }
    }
}
