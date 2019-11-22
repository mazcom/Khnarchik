using AdventureGame.ViewModels;
using AdventureGame.WPF.Kernel;
using Ninject;

namespace AdventureGame.WPF {

  public class ServiceLocator {

    private readonly IKernel kernel;

    public ServiceLocator() {

      kernel = new StandardKernel(new ServiceModule());
    }

    public MainViewModel MainViewModel {

      get {
        return kernel.Get<MainViewModel>();
      }
    }
  }
}
