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
            this.connectionString = connectionString ?? throw new AzureBusPublisherException("The connectionString parameter is null.");
        }

        public async Task Publish<T>(string topicName, T messageObject, IDictionary<string, object> headers = null)
        {
            TopicClient topicClient = null;
            try
            {
                topicClient = new TopicClient(this.connectionString, topicName, new RetryExponential(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(30), 3));
                var message = new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messageObject)));
                if (headers != null)
                    foreach (var key in headers.Keys)
                    {
                        message.UserProperties.Add(key, headers[key]);
                    }

                await topicClient.SendAsync(message);
            }
            catch (Exception ex)
            {
                throw new AzureBusPublisherException($"Error when publishing message {JsonConvert.SerializeObject(messageObject)} at topic {topicName}. See inner exception for more details.", ex);
            }
            finally
            {
                if (topicClient != null && !topicClient.IsClosedOrClosing)
                {
                    await topicClient.CloseAsync();
                }
            }
        }
    }
}
