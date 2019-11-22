using AdventureGame.Domain;
using AdventureGame.Infrastructure;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.WPF.Kernel {

  public class ServiceModule : NinjectModule {

    public override void Load() {

      //Bind<IStateRepository>().To<JsonStateRepository>().InTransientScope();
      Bind<IStateRepository>().To<FakeStateRepository>().InTransientScope();
    }
  }
}
