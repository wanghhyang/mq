using RabbitMQ.Common;
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
            QueueFactory qF = new QueueFactory(new MQModel() {
                QueueName="workerQ",
                Message = ((args.Length > 0) ? string.Join(" ", args) : "Hello World!")
            });
            //qF.CreateCommonPublisher();
            qF.QueueMessage = "hello world...";
            qF.CreateWorkerPublisher();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}