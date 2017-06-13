using MailinatorClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MailinatorClient.Core.Extensions
{
    public static class ModelExtensions
    {

        public static Attachment ToAttachment(this MessagePart mpart)
        {
            return new Attachment
            {
                Headers = mpart.Headers.ToDictionary(x => x.Key, x => x.Value),
                Data = Convert.FromBase64String(mpart.Body)
            };
        }
    }
}
