using GreenPipes;
using MassTransit;
using rabbitmq_masstransit_example.Consumer.Properties;
using rabbitmq_masstransit_example.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabbitmq_masstransit_example.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var busControl = ConfigureBus();
            busControl.Start();
        }

        static IBusControl ConfigureBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg => {
                var host = cfg.Host(new Uri($"rabbitmq://{Settings.Default.RabbitMQUri}"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, typeof(PollResult).Name, e => e.Consumer<PollResultConsumer>());
            });
        }
    }
}
