﻿using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


namespace RabitMQReceive
{
    class RPCServer
    {
        //public static void Main()
        //{
        //    //var factory = new ConnectionFactory() { HostName = "192.168.0.231" };
        //    //using (var connection = factory.CreateConnection())
        //    //using (var channel = connection.CreateModel())
        //    //{
        //    //    channel.QueueDeclare(queue: "rpc_queue",
        //    //                         durable: false,
        //    //                         exclusive: false,
        //    //                         autoDelete: false,
        //    //                         arguments: null);
        //    //    channel.BasicQos(0, 1, false);
        //    //    var consumer = new QueueingBasicConsumer(channel);
        //    //    channel.BasicConsume(queue: "rpc_queue",
        //    //                         noAck: false,
        //    //                         consumer: consumer);
        //    //    Console.WriteLine(" [x] Awaiting RPC requests");

        //    //    while (true)
        //    //    {
        //    //        string response = null;
        //    //        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

        //    //        var body = ea.Body;
        //    //        var props = ea.BasicProperties;
        //    //        var replyProps = channel.CreateBasicProperties();
        //    //        replyProps.CorrelationId = props.CorrelationId;

        //    //        try
        //    //        {
        //    //            var message = Encoding.UTF8.GetString(body);
        //    //            int n = int.Parse(message);
        //    //            Console.WriteLine(" [.] fib({0})", message);
        //    //            response = fib(n).ToString();
        //    //            System.Threading.Thread.Sleep(3000);
        //    //        }
        //    //        catch (Exception e)
        //    //        {
        //    //            Console.WriteLine(" [.] " + e.Message);
        //    //            response = "";
        //    //        }
        //    //        finally
        //    //        {
        //    //            var responseBytes = Encoding.UTF8.GetBytes(response);
        //    //            channel.BasicPublish(exchange: "",
        //    //                                 routingKey: props.ReplyTo,
        //    //                                 basicProperties: replyProps,
        //    //                                 body: responseBytes);
        //    //            channel.BasicAck(deliveryTag: ea.DeliveryTag,
        //    //                             multiple: false);
        //    //        }
        //    //    }
        //    //}
        //}

        private static int fib(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return fib(n - 1) + fib(n - 2);
        }

    }
}
