using System;
using System.Text;

namespace RabbitMQService
{
    class Program
    {
        static void Main(string[] args)
        {
            //RabbitMQ.Client.
            RabbitMQ.Client.ConnectionFactory factory = new RabbitMQ.Client.ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "yy";
            factory.Password = "hello";
            using(var connnection = factory.CreateConnection())
            {
                using (var channel = connnection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);
                    string message = "Hello world";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "hello",false, null, body);
                    Console.WriteLine(" set {0}",message );
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}