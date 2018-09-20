using RabbitMQ.Client;
using System;

namespace Common
{
    /// <summary>
    /// Common functionality in this project
    /// </summary>
    public class Utils
    {
        #region Methods
        /// <summary>
        /// Create the connection factory
        /// </summary>
        /// <returns></returns>
        public IConnectionFactory CreateConnectionFactory(string hostName)
        {
            return new ConnectionFactory() { HostName = hostName }; 
        }

        /// <summary>
        /// Setup the connection channel that will handle the messaging
        /// </summary>
        /// <returns></returns>
        public IConnection SetupConnection(IConnectionFactory connectionFactory)
        {
            return connectionFactory.CreateConnection();
        }

        /// <summary>
        /// Setup the connection channel that will handle the messaging
        /// </summary>
        /// <returns></returns>
        public IModel SetupChannel(IConnection connection, string queueName)
        {
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            return channel;
        }
        #endregion
    }
}
