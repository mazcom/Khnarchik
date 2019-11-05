using DemoCI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCI.Implementation {

  public class MessageSender {
    
    IConfirmationMessageSender _messageSender = null;

    public MessageSender(IConfirmationMessageSender messageSender) {
      _messageSender = messageSender;
    }

    public void SendMessage(string message, string recipient) {
      _messageSender.Send(message, recipient);
    }
  }
}
