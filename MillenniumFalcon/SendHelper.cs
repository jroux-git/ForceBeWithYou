using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using MillenniumFalcon.Models;

namespace MillenniumFalcon
{
    

    public class SendHelper
    {
        #region Properties
        public readonly IConnectionFactory _connectionFactory;
        #endregion

        #region Constructor
        public SendHelper(IConnectionFactory connectionFactory)
        {
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
            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);
            Console.WriteLine(" [x] Sent {0}", message);
        }

        public IModel SetupConnection()
        {
            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

               

                channel.BasicPublish(exchange: "hello_exchange",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
               

              
            }
        #endregion
    }
}
