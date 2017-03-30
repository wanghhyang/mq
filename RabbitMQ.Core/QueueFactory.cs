using System;

namespace RabbitMQ.Core
{
    public class QueueFactory
    {
        RabbitMQ.Client.ConnectionFactory factory = new RabbitMQ.Client.ConnectionFactory();
        public QueueFactory()
        {
            factory.HostName = "localhost";
            factory.UserName = "yy";
            factory.Password = "hello";
        }
        public 
    }
}
