using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageParser.Interfaces
{
    public interface IProducer
    {
        Entity.Message Produce();
        bool CanProduce { get; }
    }
}
