using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Core.BusPublisher
{
    public class AzureBusPublisher : IBusPublisher
    {
        private readonly string connectionString;

        public AzureBusPublisher(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Task Publish<T>(string queueName, T messageObject, IDictionary<string, object> headers)
        {   
            TopicClient topicClient = new TopicClient(this.connectionString, queueName, new RetryExponential(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(30), 3));
            var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messageObject)));
            foreach (var key in headers.Keys)
            {
                message.UserProperties.Add(key, headers[key]);
            }

            return topicClient.SendAsync(message);
        }
    }
}
