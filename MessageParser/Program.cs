using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageParser.Interfaces;
using Autofac;
using Autofac.Integration.Mef;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MessageParser
{
    class Program
    {
        //private CompositionContainer _container;

        private IContainer container;

        private Program()
        {
            var builder = new ContainerBuilder();
            builder.RegisterComposablePartCatalog(new AssemblyCatalog(typeof(Program).Assembly));
            //builder.RegisterComposablePartCatalog(new DirectoryCatalog(@"C:\Users\Beeven\Documents\visual studio 2013\Projects\MessageParser\MessageParser\Extensions"));
            container = builder.Build();
            
        }
        static void Main(string[] args)
        {
            Program p = new Program();

            
            using(var scope = p.container.BeginLifetimeScope())
            {
                List<IProducer> producers = new List<IProducer>();
                List<IConsumer> consumers = new List<IConsumer>();
                for (int i = 0; i < 3; i++)
                {
                    producers.Add(p.container.Resolve<IProducer>());
                }
                consumers.Add(p.container.Resolve<IConsumer>());

                IWorker worker = new Internal.SequencialWorker(producers, consumers);
                worker.DoWork();
            }
            //var worker = p.container.Resolve<IWorker>();

            
        }
    }
}
