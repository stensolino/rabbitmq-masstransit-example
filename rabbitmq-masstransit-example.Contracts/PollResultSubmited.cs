using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabbitmq_masstransit_example.Contracts
{
    public interface PollResultSubmited
    {
        int Count { get; set; }
        string Name { get; set; }
    }
}
