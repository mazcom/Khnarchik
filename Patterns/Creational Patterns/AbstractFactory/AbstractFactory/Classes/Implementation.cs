using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Classes {
  class CocaColaFactory : AbstractFactory {
    public override AbstractWater CreateWater() {
      return new CocaColaWater();
    }
    public override AbstractBottle CreateBottle() {
      return new CocaColaBottle();
    }
  }


  class CocaColaWater : AbstractWater {
  }

  class CocaColaBottle : AbstractBottle {
    public override void Interact(AbstractWater water) {

      Console.WriteLine(this + " interacts with " + water);
    }
  }

}
