﻿using MassTransit;
using rabbitmq_masstransit_example.Contracts;
using rabbitmq_masstransit_example.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabbitmq_masstransit_example
{
    class Program
    {
        static void Main(string[] args)
        {
            var busControl = ConfigureBus();
            busControl.Start();

            do
            {
                Console.WriteLine("Enter message (or quit to exit)");
                Console.Write("> ");
                string value = Console.ReadLine();

                if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                    break;

                busControl.Publish<PollResultSubmited>(new
                {
                    Count = 15,
                    Name = value
                });

            } while (true);

            busControl.Stop();
        }

        static IBusControl ConfigureBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri($"rabbitmq://{Settings.Default.RabbitMQUri}"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
        }
    }
}
