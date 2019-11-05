using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCI.Interfaces {

  public interface IConfirmationMessageSender {
    void Send(string message, string recipient);
  }
}
