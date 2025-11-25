using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Garage
{
    public abstract class Application
    {
        public ConsoleColor LogColor = ConsoleColor.Cyan;
        public string Name { get; }
        public string LogName { get; private init; }
        public ApplicationStatus Status { get; private set; } = new(0);
        public Exception? Exception { get; private set; }
        public ChannelWriter<ApplicationMessage>? Writer { get; private set; }
        public ChannelReader<ApplicationMessage>? Reader { get; private set; }

        public Application(string name, ChannelWriter<ApplicationMessage> writer)
        {
            Name = name;
            LogName = name.ToUpper().Replace(' ', '_');
            Writer = writer;
            Reader = null;
        }
        public Application(string name, ChannelReader<ApplicationMessage> reader)
        {
            Name = name;
            LogName = name.ToUpper().Replace(' ', '_');
            Reader = reader;
            Writer = null;
        }
        public abstract ApplicationStatus Run();
    }
}
