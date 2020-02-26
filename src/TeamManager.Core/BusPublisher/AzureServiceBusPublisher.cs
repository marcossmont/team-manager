using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Core.BusPublisher
{
    public class AzureServiceBusPublisher : IBusPublisher
    {
        private readonly string _connectionsString;

        public AzureServiceBusPublisher(string connectionsString)
        {
            _connectionsString = connectionsString ?? throw new ArgumentNullException(nameof(connectionsString));
        }

        public async Task Publish<T>(string queueName, T message)
        {
            var queueClient = new QueueClient(_connectionsString, queueName, ReceiveMode.PeekLock, new RetryExponential(
                TimeSpan.FromSeconds(0),
                TimeSpan.FromSeconds(30),
                3));
           
            try
            {
                var serializedMessage = JsonConvert.SerializeObject(message);
                await queueClient.SendAsync(new Message(Encoding.UTF8.GetBytes(serializedMessage)));
            }
            finally
            {
                if (!queueClient.IsClosedOrClosing)
                    await queueClient.CloseAsync();
            }
        }
    }
}
