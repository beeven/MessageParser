using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MessageParser.Interfaces;

namespace MessageParser.DummyConsumers
{
    public class Module: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new FileConsumer()).As<IConsumer>();
        }
    }
}
