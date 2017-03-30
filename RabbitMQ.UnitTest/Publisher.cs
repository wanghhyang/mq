using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQ.Core;

namespace RabbitMQ.UnitTest
{
    [TestClass]
    public class Publisher
    {
        [TestMethod]
        public void CommonQueue()
        {
            QueueFactory qF = new QueueFactory();
            qF.CreateCommonPublisher();
        }
    }
}
