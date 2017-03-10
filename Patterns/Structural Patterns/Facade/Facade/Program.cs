using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade {
  class Program {
    static void Main(string[] args) {

      Facade.Classes.Facade facade = new Facade.Classes.Facade();

      facade.MethodA();
      facade.MethodB();

      // Wait for user
      Console.ReadKey();
    }
  }
}
