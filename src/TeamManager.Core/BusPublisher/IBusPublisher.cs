using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TeamManager.Core.BusPublisher
{
    public interface IBusPublisher
    {
        Task Publish<T>(string queueName, T message);
    }
}
