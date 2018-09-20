using System;
using MillenniumFalcon.Models;
using RabbitMQ.Client;

namespace MillenniumFalcon
{
    class Program
    {
        #region Fields
        private static readonly string _hostName = "localhost";
        #endregion"localhost"

        /// <summary>
        /// Entry point to the sender application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = _hostName };
            SendHelper sendHelper = new SendHelper(factory);
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
