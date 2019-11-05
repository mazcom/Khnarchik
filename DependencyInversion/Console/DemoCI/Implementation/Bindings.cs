using DemoCI.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCI.Implementation {

  public class Bindings : NinjectModule {
    
    public override void Load() {

      Bind<IConfirmationMessageSender>().To<SMSMessageSender>();
    }
  }
}
