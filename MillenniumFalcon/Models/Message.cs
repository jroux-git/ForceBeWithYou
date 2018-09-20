
namespace MillenniumFalcon.Models
{
    /// <summary>
    /// Construct a message that will be used to post to the queue
    /// </summary>
    public class Message
    {
        #region Properties
        private string _messageText { get; set; }
        public string MessageText
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
        #endregion

        #region Constructor
        public Message(string messageText)
        {
            _messageText = messageText;
        }
        #endregion
    }
}
