using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace simplehttp
{
    public class Sbaa
    {
        private readonly ILogger<Sbaa> _logger;

        public Sbaa(ILogger<Sbaa> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Sbaa))]
        public async Task Run(
            [ServiceBusTrigger("tempqueue", Connection = "SbStrConn")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
