using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Garage
{
    internal class MessageQueue
    {
        private readonly Channel<IApplicationEvent> _channel = 
            Channel.CreateUnbounded<IApplicationEvent>();

        public ChannelReader<IApplicationEvent> Reader => _channel.Reader;
        public ChannelWriter<IApplicationEvent> Writer => _channel.Writer;
    }
}
