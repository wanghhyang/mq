using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ;
using RabbitMQ.Client.Events;
using System.Threading;

namespace RabbitMQ.ConsumerFactory
{
    public class WorkerQueueConsumer: IConsumer
    {
        public void CreateOneConsumer()
        {
            using (var connection = new MQConsumerFactory().ConnectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("workerQ", false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) => {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        int dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);

                        Console.WriteLine("Received {0}", message);
                        Console.WriteLine("Done");
                    };
                }
            }
        }
    }
}
