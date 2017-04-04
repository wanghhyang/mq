using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.ConsumerFactory;
using System;
using System.Text;

namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            IConsumer consumer=new WorkerQueueConsumer();
            consumer.CreateOneConsumer();
            Console.ReadKey();
        }
    }
}