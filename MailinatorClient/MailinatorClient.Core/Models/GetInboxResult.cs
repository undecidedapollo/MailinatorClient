using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailinatorClient.Core.Models
{
    public class GetInboxResult
    {
        public List<Message> Messages { get; set; }
        [JsonProperty("enc_to")]
        public string EncTo{ get; set; }
        public string To { get; set; }
    }
}
