using MessageParser.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MessageParser.Internal
{
    public class SequencialWorker:IWorker
    {
        public System.Collections.Concurrent.ConcurrentQueue<MessageParser.Interfaces.Entity.Message> queue;
        System.Threading.ManualResetEventSlim completeEvent;
        IEnumerable<IProducer> producers;
        IEnumerable<IConsumer> consumers;
        
        public SequencialWorker(IEnumerable<IProducer> producers, IEnumerable<IConsumer> consumers)
        {
            queue = new System.Collections.Concurrent.ConcurrentQueue<Interfaces.Entity.Message>();
            completeEvent = new System.Threading.ManualResetEventSlim(false);
            this.producers = producers;
            this.consumers = consumers;
        }
        public void DoWork()
        {   
            var producerHandle = Task.Run(() => {
                Parallel.ForEach(producers, (p) =>
                {
                    while (p.CanProduce)
                    {
                        queue.Enqueue(p.Produce());
                    }
                });
                completeEvent.Set();
            });

            var consumerHandle = Task.Run(() =>
            {
                Parallel.ForEach(consumers, (c) =>
                 {
                     MessageParser.Interfaces.Entity.Message msg;
                     while (!completeEvent.IsSet || !queue.IsEmpty)
                     {
                         if(queue.TryDequeue(out msg))
                         {
                             c.Consume(msg);
                         }
                     }
                 });
            });

            Task.WaitAll(producerHandle, consumerHandle);
            
        }

        
    }
}
