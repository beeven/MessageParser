using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageParser.DummyProducers
{
    
    [Export(typeof(MessageParser.Interfaces.IProducer))]
    [ExportMetadata("Strategy","Random")]
    public class RandomProducer: MessageParser.Interfaces.IProducer
    {
        private Random rand;

        private int loopingId = 0;
        public RandomProducer()
        {
            rand = new Random();
        }

        public Interfaces.Entity.Message Produce()
        {
            return new Interfaces.Entity.Message()
            {
                Id = loopingId++ % 100,
                Value = rand.Next()
            };
        }


        public bool CanProduce
        {
            get
            {
                return loopingId < 1000;
            }
        }
    }
}
