using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQ.Core;

namespace RabbitMQ.UnitTest
{
    [TestClass]
    public class Publisher
    {
        [TestMethod]
        public void CreateCommonQueue()
        {
            QueueFactory qF = new QueueFactory();
            qF.CreateCommonPublisher();
        }

        [TestMethod]
        public void CreateWorkerQueue()
        {
            QueueFactory qF = new QueueFactory(new Common.MQModel() {
                QueueName="workerQ",
                Message="a.b.c.d"
            });
            qF.CreateWorkerPublisher();
        }
    }
}
