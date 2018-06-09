using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Attributes;
using RawRabbit.Common;
using RawRabbit.Configuration;
using RawRabbit.Serialization;
using RawRabbit.vNext;
using Sender.Events;
using System;
using System.IO;

namespace Sender
{
    class Receiver
    {
        private static IBusClient _busClient;

        static void Main(string[] args)
        {
            createClient();

            Console.WriteLine("Press key to publish string message");
            Console.ReadKey();

            _busClient.PublishAsync<NameChanged>(new NameChanged("Jan"), Guid.NewGuid(),
                cfg => cfg.WithExchange(ex => ex.WithName("exchange_test")));

            Console.WriteLine("Press key to publish int message");
            Console.ReadKey();
            _busClient.PublishAsync<AgeChanged>(new AgeChanged(99), Guid.NewGuid(),
                cfg => cfg.WithExchange(ex => ex.WithName("exchange_test")));

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void createClient()
        {
            _busClient = BusClientFactory.CreateDefault(cfg =>
                                             new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("rawrabbit.json")
                                            .Build().Get<RawRabbitConfiguration>(),
                                                        (s) => s.AddTransient<IMessageSerializer, CustomSerializer>()
                                                        .AddSingleton<IConfigurationEvaluator,AttributeConfigEvaluator>());

            //_busClient = BusClientFactory.CreateDefault(
            //                                 new ConfigurationBuilder()
            //                                .SetBasePath(Directory.GetCurrentDirectory())
            //                                .AddJsonFile("rawrabbit.json")
            //                                .Build().Get<RawRabbitConfiguration>());
        }
    }
}
