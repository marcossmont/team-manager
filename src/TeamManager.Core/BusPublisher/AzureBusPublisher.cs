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

        public Task Publish<T>(string queueName, T messageObject, Hashtable headers)
        {   
            TopicClient topicClient = new TopicClient(this.connectionString, queueName, new RetryExponential(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(30), 3));
            var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messageObject)));
            return topicClient.SendAsync(message);
        }
    }
}
