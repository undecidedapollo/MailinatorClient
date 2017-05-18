using MailinatorClient.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MailinatorClient.AspNetCore
{
    public static class MailinatorApplicationBuilder
    {
        public static IServiceCollection SetupMailinatorClient(this IServiceCollection app, string apiKey)
        {
            if (app == null) throw new ArgumentNullException($"{nameof(app)} cannot be null.");
            if (apiKey == null) throw new ArgumentNullException($"{nameof(apiKey)} cannot be null.");

            app.AddTransient(x => new StandardMailinatorClient(apiKey));

            return app;
        }
    }
}
