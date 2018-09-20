using System;
using System.Collections.Generic;
using System.Text;

namespace MillenniumFalcon.Models
{
    /// <summary>
    /// Object to construct the connection properties for the message queue
    /// </summary>
    public class ConnectionProperties
    {
        #region Properties
        private string _hostName { get; set; }
        public string HostName
        {
            get
            {
                return _hostName;
            }
            set
            {
                _hostName = value;
            }
        }

        private string _exchange { get; set; }
        public string Exchange
    {
            get
            {
                return _exchange;
            }
            set
            {
                _exchange = value;
            }
        }

        private string _queueName { get; set; }
        public string QueueName
        {
            get
            {
                return _queueName;
            }
            set
            {
                _queueName = value;
            }
        }

        private string _routingKey { get; set; }
        public string RoutingKey
        {
            get
            {
                return _routingKey;
            }
            set
            {
                _routingKey = value;
            }
        }
        #endregion

        #region Constructor
        public ConnectionProperties(string hostName, string exchange, string routingKey, string queueName)
        {
            HostName = hostName;
            Exchange = exchange;
            RoutingKey = routingKey;
            QueueName = queueName;
        }
        #endregion
    }
}
