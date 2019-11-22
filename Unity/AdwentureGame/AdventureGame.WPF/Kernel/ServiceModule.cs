using AdventureGame.Domain;
using AdventureGame.Infrastructure;
using Ninject.Modules;

namespace AdventureGame.WPF.Kernel {

  public class ServiceModule : NinjectModule {

    public override void Load() {

      Bind<IStateRepository>().To<FakeStateRepository>().InTransientScope();
    }
  }
}
