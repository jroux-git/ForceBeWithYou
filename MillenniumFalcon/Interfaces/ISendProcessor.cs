using MillenniumFalcon.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MillenniumFalcon.Interfaces
{
    public interface ISendProcessor
    {
        void SendToQueue(Message message);
    }
}
