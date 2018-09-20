using System;
using System.Text;
using RabbitMQ.Client;
using MillenniumFalcon.Models;
using Common;
using MillenniumFalcon.Interfaces;

namespace MillenniumFalcon
{
    /// <summary>
    /// This class pushes messages onto the message queue
    /// </summary>
    public class SendProcessor : ISendProcessor
    {
        #region Properties
        private readonly IConnectionFactory _connectionFactory;
        private readonly ConnectionProperties _connectionProperties;
        private Utils _utils;
        #endregion

        #region Constructor
        public SendProcessor(IConnectionFactory connectionFactory, ConnectionProperties connectionProperties)
        {
            _connectionProperties = connectionProperties;
            _utils = new Utils();
            _connectionFactory = connectionFactory;
        }
        #endregion

        #region Method
        /// <summary>
        /// Accepts a message and sends it off to the queue
        /// </summary>
        /// <param name="message"></param>
        public void SendToQueue(Message message)
        {
            var body = Encoding.UTF8.GetBytes(message.MessageText);
            IConnection connection = _utils.SetupConnection(_connectionFactory);

            using (connection)
            {
                var channel = _utils.SetupChannel(connection, _connectionProperties.QueueName);
                using (channel)
                {
                    channel.BasicPublish(exchange: _connectionProperties.Exchange,
                                        routingKey: _connectionProperties.RoutingKey,
                                        basicProperties: null,
                                        body: body);

                    Console.WriteLine($" > Message Sent: {message.MessageText}");
                }
            }
        }
        #endregion
    }
}
