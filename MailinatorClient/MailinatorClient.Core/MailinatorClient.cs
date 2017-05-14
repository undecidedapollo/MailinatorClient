using MailinatorClient.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MailinatorClient.Core
{
    public class MailinatorClient
    {
        public string ApiKey { get; protected set; }

        private static readonly string baseUrl = "https://api.mailinator.com";

        public MailinatorClient(string apiKey)
        {
            this.ApiKey = apiKey ?? throw new ArgumentNullException("ApiKey cannot be null.");
        }

        public virtual async Task<GetInboxResult> GetInbox(string inboxName, bool usePrivate = false)
        {
            using(var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}/api/inbox?token={this.ApiKey}&private_domain={usePrivate}&to={inboxName}");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GetInboxResult>(content);
            }
        }

        public virtual async Task<GetInboxResult> GetSavedInbox()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}/api/inbox?token={this.ApiKey}");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GetInboxResult>(content);
            }
        }

        public virtual async Task<GetMessageResult> GetMessage(string messageId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{baseUrl}/api/email?token={this.ApiKey}&id={messageId}");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GetMessageResult>(content);
            }
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
