using DemoCI.Implementation;
using DemoCI.Interfaces;
using Ninject;
using System;
using System.Reflection;

namespace DemoCI {
  class Program {
    static void Main(string[] args) {

      IKernel kernel = new StandardKernel();
      kernel.Load(Assembly.GetExecutingAssembly());
      IConfirmationMessageSender confirmationMessage = kernel.Get<IConfirmationMessageSender>();
      MessageSender messageSender = new MessageSender(confirmationMessage);
      messageSender.SendMessage("Some text", "123456789");
      Console.ReadKey();
    }
  }
}
