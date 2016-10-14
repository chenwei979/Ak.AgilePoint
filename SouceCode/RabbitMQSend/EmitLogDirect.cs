using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQSend
{
    class EmitLogDirect
    {
        //public static void Main(string[] args)
        //{
        //    var factory = new ConnectionFactory() { HostName = "192.168.0.231" };
        //    using (var connection = factory.CreateConnection())
        //    using (var channel = connection.CreateModel())
        //    {
        //        for (long i = 0; i < 100000000;i ++ )
        //        { 
        //            channel.ExchangeDeclare(exchange: "direct_logs",
        //                                    type: "direct");

        //        var severity = (args.Length > 0) ? args[0] : "info";
        //        var message = (args.Length > 1)
        //                      ? string.Join(" ", args.Skip(1).ToArray())
        //                      : "Hello World!";
        //        var body = Encoding.UTF8.GetBytes(message);
        //        channel.BasicPublish(exchange: "direct_logs",
        //                             routingKey: severity,
        //                             basicProperties: null,
        //                             body: body);
        //        Console.WriteLine(" [x] Sent '{0}':'{1}'", severity, message);
        //        }
        //    }

        //    Console.WriteLine(" Press [enter] to exit.");
        //    Console.ReadLine();
        //}
    }
}
