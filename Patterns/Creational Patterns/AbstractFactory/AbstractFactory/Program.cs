using AbstractFactory.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory {
  class Program {
    static void Main(string[] args) {

      Console.WriteLine("start program...");

      Client client = null;
      client = new Client(new CocaColaFactory());
      client.Run();

      Console.WriteLine("end program...");
      Console.ReadKey();
    }
  }
}
