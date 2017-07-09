using MassTransit;
using rabbitmq_masstransit_example.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabbitmq_masstransit_example.Consumer
{
    class PollResultConsumer : IConsumer<PollResult>
    {
        public async Task Consume(ConsumeContext<PollResult> context)
        {
            await Console.Out.WriteLineAsync($"Updating poll result: {context.Message.Name}");

            // update poll result logic
        }
    }
}
