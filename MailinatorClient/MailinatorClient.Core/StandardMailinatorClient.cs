using MailinatorClient.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MailinatorClient.Core
{
    public class StandardMailinatorClient : IMailinatorClient
    {
        public string ApiKey { get; protected set; }

        private static readonly string baseUrl = "https://api.mailinator.com";

        public StandardMailinatorClient(string apiKey)
        {
            this.ApiKey = apiKey ?? throw new ArgumentNullException("ApiKey cannot be null.");
        }

        public virtual async Task<GetInboxResult> GetInbox(string inboxName, bool usePrivate = false)
        {
            using(var client = new HttpClient())
            {
                var url = $"{baseUrl}/api/inbox?token={this.ApiKey}&private_domain={usePrivate.ToString().ToLower()}&to={inboxName}";

                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<GetInboxResult>(content);

                if(result?.Messages != null && usePrivate)
                {
                    result.Messages.ForEach(x => x.IsPrivateMessage = true);
                }

                return result;
            }
        }

        public virtual async Task<GetInboxResult> GetSavedInbox()
        {
            using (var client = new HttpClient())
            {
                var url = $"{baseUrl}/api/inbox?token={this.ApiKey}";
                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GetInboxResult>(content);
            }
        }

        public virtual async Task<GetMessageResult> GetMessage(string messageId, bool usePrivate = false)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}/api/email?token={this.ApiKey}&id={messageId}&private_domain={usePrivate.ToString().ToLower()}");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var message = JsonConvert.DeserializeObject<GetMessageResult>(content);

                if(message?.Data != null && usePrivate)
                {
                    message.Data.IsPrivateMessage = true;
                }

                return message;
            }
        }

        public virtual async Task<GetMessageResult> GetFullMessage(Message message)
        {
            return await this.GetMessage(message?.Id, message?.IsPrivateMessage ?? false);
        }

        public virtual async Task<GetMessageResult> DeleteMessage(string messageId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}/api/delete?token={this.ApiKey}&id={messageId}");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GetMessageResult>(content);
            }
        }
    }
}
