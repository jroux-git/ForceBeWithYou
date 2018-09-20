using Common;
using DeathStar.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace DeathStar
{
    /// <summary>
    /// This class reads the messages off the message queue
    /// </summary>
    public class ReceiveProcessor : IReceiveProcessor
    {
        #region Fields
        #region Properties
        private readonly IConnectionFactory _connectionFactory;
        private Utils _utils;
        private readonly string _queueName;
        #endregion
        #endregion

        #region Constructor
        public ReceiveProcessor(IConnectionFactory connectionFactory, string queueName)
        {
            _queueName = queueName;
            _utils = new Utils();
            _connectionFactory = connectionFactory;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Process messages coming off the queue
        /// </summary>
        public void ReceiveFromQueue()
        {
            IConnection connection = _utils.SetupConnection(_connectionFactory);

            using (connection)
            {
                var channel = _utils.SetupChannel(connection, _queueName);
                using (channel)
                {
                    channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($" > Hello {message}, I am your father!");
                    };
                    channel.BasicConsume(queue: _queueName,
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
        #endregion
    }
}
