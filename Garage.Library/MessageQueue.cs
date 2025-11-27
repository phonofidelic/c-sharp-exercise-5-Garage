using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Garage.Library
{
    public class MessageQueue
    {
        private readonly Channel<ApplicationEvent> _channel =
            Channel.CreateUnbounded<ApplicationEvent>();

        public ChannelReader<ApplicationEvent> Reader => _channel.Reader;
        public ChannelWriter<ApplicationEvent> Writer => _channel.Writer;
    }
}
