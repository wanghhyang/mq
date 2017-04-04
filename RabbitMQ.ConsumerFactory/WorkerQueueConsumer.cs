using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ;

namespace RabbitMQ.ConsumerFactory
{
    public class WorkerQueueConsumer
    {
        public void Consume()
        {
            using (var connection=new MQConsumerFactory().ConnectionFactory.CreateConnection())
            {
                using (var channel=connection.CreateModel())
                {
                    channel.QueueDeclare("workerQ", false, false, false, null);

                }
            }
        }
    }
}
