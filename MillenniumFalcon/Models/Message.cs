
namespace MillenniumFalcon.Models
{
    /// <summary>
    /// Construct a message that will be used to post to the queue
    /// </summary>
    public class Message
    {
        private string _messageText { get; set; }
        public string Value
        {
            get
            {
                return _messageText;
            }
            set
            {
                _messageText = value;
            }
        }

        public Message(string messageText)
        {
            _messageText = messageText;
        }
    }
}
