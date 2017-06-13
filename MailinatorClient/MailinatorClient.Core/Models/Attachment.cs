using System;
using System.Collections.Generic;
using System.Text;

namespace MailinatorClient.Core.Models
{
    public class Attachment
    {
        public Dictionary<string, string> Headers { get; set; }

        public byte[] Data { get; set; }
    }
}
