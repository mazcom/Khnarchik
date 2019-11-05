using DemoCI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCI.Implementation {

  public class SMSMessageSender : IConfirmationMessageSender {
    public void Send(string message, string recipient) {
      Console.WriteLine("SMS recipient={0} : data={1}", recipient, message);
    }
  }
}
