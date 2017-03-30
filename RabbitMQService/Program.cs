using RabbitMQ.Core;
using System;
using System.Text;

namespace RabbitMQService
{
    class Program
    {
        static void Main(string[] args)
        {
            //RabbitMQ.Client.
            QueueFactory qF = new QueueFactory();
            qF.CreateCommonPublisher();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}