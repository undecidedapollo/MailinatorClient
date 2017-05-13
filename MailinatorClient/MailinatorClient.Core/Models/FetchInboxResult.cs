using System;
using System.Collections.Generic;
using System.Text;

namespace MailinatorClient.Core.Models
{
    public class FetchInboxResult
    {
        public ICollection<Message> Messages { get; set; }
    }
}
