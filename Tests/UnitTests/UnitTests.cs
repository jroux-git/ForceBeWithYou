using System;
using Xunit;
using RabbitMQ.Fakes;
using MillenniumFalcon;
using DeathStar;
using MillenniumFalcon.Models;
using Common;
using System.Linq;
using System.Text;
using DeathStar.Interfaces;
using MillenniumFalcon.Interfaces;

namespace UnitTests
{
    public class UnitTests
    {
        [Fact]
        public void SendToExchangeOnly()
        {
            // Arrange
            Message message = new Message("Test Message");
            ConnectionProperties connectionProperties = new ConnectionProperties("localhost", "test", "queue_vader",  "queue_vader");
            var rabbitServer = new RabbitServer();
            var connectionFactory = new FakeConnectionFactory(rabbitServer);
            SendProcessor sendProcessor = new SendProcessor(connectionFactory, connectionProperties);

            // Act
            sendProcessor.SendToQueue(message);

            // Assert
            Assert.Equal(1, rabbitServer.Exchanges["test"].Messages.Count);
        }

        [Fact]
        public void CheckClosedConnection()
        {
            // Arrange
            Utils utils = new Utils();
            var rabbitServer = new RabbitServer();
            var connectionFactory = new FakeConnectionFactory(rabbitServer);
            var connection = utils.SetupConnection(connectionFactory);

            // Act
            connection.Close();

            // Assert
            Assert.False(connection.IsOpen);
            Assert.NotNull(connection.CloseReason);
        }

        [Fact]
        public void TestMessageInQueue()
        {
            // Arrange
            Message message = new Message("Test Message");
            ConnectionProperties connectionProperties = new ConnectionProperties("localhost", "test", "queue_vader", "queue_vader");
            var rabbitServer = new RabbitServer();
            var connectionFactory = new FakeConnectionFactory(rabbitServer);
            ISendProcessor sendProcessor = new SendProcessor(connectionFactory, connectionProperties);

            // Act
            sendProcessor.SendToQueue(message);

            // Assert
            Assert.Equal(Encoding.UTF8.GetBytes("Test Message"), rabbitServer.Exchanges["test"].Messages.First().Body);
        }
    }
}
