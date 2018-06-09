using Microsoft.Extensions.Configuration;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Context;
using RawRabbit.vNext;
using Receiver.Events;
using Receiver.Messages;
using System;
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

            _busClient.SubscribeAsync<MessageBase>((msg, ctx) => subscribeMsg(msg, ctx),
                cfg => cfg.WithExchange(ex => ex.WithName("exchange_test")).WithRoutingKey("test_routing_key"));

            Console.ReadKey();
        }

        private static void createClient()
        {
            _busClient = BusClientFactory.CreateDefault(
                  new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("rawrabbit.json")
                 .Build().Get<RawRabbitConfiguration>());
        }

        private static Task subscribeMsg(MessageBase msg, MessageContext ctx)
        {
            getSpecificAction(msg)();
            Console.WriteLine(msg);
            return Task.CompletedTask;
        }

        private static Action getSpecificAction(MessageBase msg)
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
