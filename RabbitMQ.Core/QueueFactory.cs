using System;
using System.Text;

namespace RabbitMQ.Core
{
    public class QueueFactory
    {
        RabbitMQ.Client.ConnectionFactory factory = new RabbitMQ.Client.ConnectionFactory();
        private string shareQueueName = "testQ";
        private string queueName = string.Empty; 
        public string QueueMessage
        {
            get;set;
        }
          
        public QueueFactory()
        {
            factory.HostName = "localhost";
            factory.UserName = "yy";
            factory.Password = "123123";
            this.queueName = shareQueueName;
        }
        public QueueFactory(string queueName):this()
        {
            this.queueName = queueName;
        }
        /// <summary>
        /// 创建一个普通的队列发布者
        /// </summary>
        public void CreateCommonPublisher()
        {
            using (var connnection = factory.CreateConnection())
            {
                using (var channel = connnection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);
                    string message = QueueMessage;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", queueName, false, null, body);
#if DEBUG
                    Console.WriteLine(" set {0}", message);
#endif

                }
            }
        }
        public void CreateWorkerPublisher()
        {
            using (var connection =factory.CreateConnection())
            {
                using (var channel=connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);
                    string message = QueueMessage;
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "hello",false, properties, body);
                    Console.WriteLine(" set {0}", message);
                }
            }
        }        
    }
}
