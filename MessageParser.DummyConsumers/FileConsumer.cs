using MessageParser.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageParser.DummyConsumers
{
    [Export(typeof(IConsumer))]
    [ExportMetadata("Target","File")]
    public class FileConsumer:IConsumer
    {
        public bool Consume(Interfaces.Entity.Message msg)
        {
            throw new NotImplementedException();
        }
    }
}
