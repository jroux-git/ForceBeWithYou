using Common;
using DeathStar.Interfaces;
using RabbitMQ.Client;
using System;
using System.Text;

namespace DeathStar
{
    class Program
    {
        #region Fields
        private static readonly string _hostName = "localhost";
        private static readonly string _queue = "queue_vader";
        #endregion

        static void Main(string[] args)
        {
            Utils utils = new Utils();
            IConnectionFactory connectionFactory = utils.CreateConnectionFactory(_hostName);
            IReceiveProcessor receiveProcessor = new ReceiveProcessor(connectionFactory, _queue);
            receiveProcessor.ReceiveFromQueue();
        }
    }
}
