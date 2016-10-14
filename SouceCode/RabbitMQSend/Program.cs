using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQSend
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var factory = new ConnectionFactory() { HostName = "192.168.0.231" };
        //    using (var connection = factory.CreateConnection())
        //    using (var channel = connection.CreateModel())
        //    {
        //        channel.QueueDeclare(queue: "hello1", durable: false, exclusive: false, autoDelete: false, arguments: null);

        //        for (int i = 0; i < 10000; i++)
        //        {
        //            string message = "Hello World!";
        //            var body = Encoding.UTF8.GetBytes(message);

        //            channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
        //            Console.WriteLine(" [x] Sent {0}", message);
        //        }
        //    }

        //    Console.WriteLine(" Press [enter] to exit.");
        //    Console.ReadLine();
        //}
    }
}
