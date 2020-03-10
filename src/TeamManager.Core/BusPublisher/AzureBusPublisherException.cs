using System;
using System.Runtime.Serialization;

namespace TeamManager.Core.BusPublisher
{
    [Serializable]
    internal class AzureBusPublisherException : Exception
    {
        public AzureBusPublisherException()
        {
        }

        public AzureBusPublisherException(string message) : base(message)
        {
        }

        public AzureBusPublisherException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AzureBusPublisherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}