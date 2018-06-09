using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Context;
using RawRabbit.Serialization;
using RawRabbit.vNext;
using Receiver.Messages;
using System;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;

namespace Receiver
{
    class Receiver
    {
        private static IBusClient _busClient;

        static void Main(string[] args)
        {
            createClient();

            _busClient.SubscribeAsync<dynamic>((msg, ctx) => subscribeMsg(msg, ctx),
                cfg => cfg.WithExchange(ex => ex.WithName("exchange_test")).WithRoutingKey("test_routing_key"));

            Console.ReadKey();
        }

        private static void createClient()
        {
            //_busClient = BusClientFactory.CreateDefault(
            //                                new ConfigurationBuilder()
            //                               .SetBasePath(Directory.GetCurrentDirectory())
            //                               .AddJsonFile("rawrabbit.json")
            //                               .Build().Get<RawRabbitConfiguration>());
            _busClient = BusClientFactory.CreateDefault(cfg =>
                                             new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("rawrabbit.json")
                                            .Build().Get<RawRabbitConfiguration>(),
                                                        (s) => s.AddTransient<IMessageSerializer, CustomSerializer>());

        }

        private static Task subscribeMsg(object msg, MessageContext ctx)
        {
            getSpecificAction(msg)();
            Console.WriteLine(msg);
            return Task.CompletedTask;
        }

        private static Action getSpecificAction(object msg)
        {
            switch (msg)
            {
                case PrintStringMessage p:
                    return () => Console.WriteLine($"String message: {p.StringValue}");
                case PrintIntMessage im:
                    return () => Console.WriteLine($"Int message: {im.IntValue}");
                default:
                    return () => Console.WriteLine("Default message.");
            }
        }
    }
}
