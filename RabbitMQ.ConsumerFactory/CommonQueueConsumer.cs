using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.ConsumerFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.Consumer
{
    public class CommonQueueConsumer: IConsumer
    {
        public void CreateOneConsumer()
        {
            using (var connection = new MQConsumerFactory().ConnectionFactory.CreateConnection())
            {
                {
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare("hello", false, false, false, null);
                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body;
                            var message = Encoding.UTF8.GetString(body);
                            Console.WriteLine("Received {0}", message);
                        };
                        channel.BasicConsume(queue: "hello",
                                             noAck: true,
                                             consumer: consumer);

                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
