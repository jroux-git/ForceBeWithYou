using System;
using Common;
using MillenniumFalcon.Interfaces;
using MillenniumFalcon.Models;
using RabbitMQ.Client;

namespace MillenniumFalcon
{
    class Program
    {
        #region Fields
        private static readonly string _hostName = "localhost";
        private static readonly string _exchange = "";
        private static readonly string _routingKey = "queue_vader";
        private static readonly string _queue = "queue_vader";
        #endregion

        /// <summary>
        /// Entry point to the sender application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ConnectionProperties connectionProperties = new ConnectionProperties(_hostName, _exchange, _routingKey, _queue);
            Utils utils = new Utils();
            IConnectionFactory connectionFactory = utils.CreateConnectionFactory(connectionProperties.HostName);
            ISendProcessor sendHelper = new SendProcessor(connectionFactory, connectionProperties);
            Message message = UserPrompts();
            sendHelper.SendToQueue(message);

            Console.WriteLine(" Press [enter] to exit.");
            Console.Read();
        }

        /// <summary>
        /// Setup UI to accept user input and validate.
        /// </summary>
        /// <returns>
        /// <c>Message</c>
        /// <see cref="Message"/>
        /// a message object containing the required content to pass to the queue
        /// </returns>
        public static Message UserPrompts()
        {
            string name = "";

            do
            {
                Console.Clear();
                Console.Write("Please Enter your name: ");
                name = Console.ReadLine().Trim();
            } while (name == "");
            

            Message message = new Message(name);

            return message;
        }
    }
}
