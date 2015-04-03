using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageParser.Interfaces;
using System.ComponentModel.Composition;
namespace MessageParser.Internal
{
    [Export(typeof(IConsumer))]
    [ExportMetadata("Target","Console")]
    public class ConsoleConsumer:IConsumer
    {
        public bool Consume(Interfaces.Entity.Message msg)
        {
            Console.WriteLine("Consumed message: Id {0}, Value {1}",msg.Id,msg.Value);
            return true;
        }
    }
}
