using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ.ConsumerFactory
{
   public class MQConsumerFactory
    {
        private ConnectionFactory factory = new ConnectionFactory();
        public MQConsumerFactory()
        {
            factory.HostName = "localhost";
            factory.UserName = "yy";
            factory.Password = "123123";
        }
        public ConnectionFactory ConnectionFactory
        {
            get
            {
                return this.factory;
            }
        }
    }
}
