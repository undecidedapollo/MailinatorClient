using MailinatorClient.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MailinatorClient.Core
{
    public interface IMailinatorClient
    {
        Task<GetInboxResult> GetInbox(string inboxName, bool usePrivate = false);

        Task<GetInboxResult> GetSavedInbox();

        Task<GetMessageResult> GetMessage(string messageId, bool usePrivate = false);

        Task<GetMessageResult> GetFullMessage(Message message);

        Task<GetMessageResult> DeleteMessage(string messageId);
    }
}
