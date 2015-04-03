using MessageParser.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageParser.Internal
{
    [Export(typeof(IProducer))]
    [ExportMetadata("Strategy","Looping")]
    public class IncrementalProducer:IProducer
    {
        int incrementalId = 0;
        int incrementalValue = 0;
        public IncrementalProducer()
        {

        }
        public Interfaces.Entity.Message Produce()
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("Produced: Id {0}, Value {1}", incrementalId++, incrementalValue++);
            return new Interfaces.Entity.Message() { Id = incrementalId, Value = incrementalValue };
        }


        public bool CanProduce
        {
            get { return incrementalValue < 500; }
        }
    }
}
