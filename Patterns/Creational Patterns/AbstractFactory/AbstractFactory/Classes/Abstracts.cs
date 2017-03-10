using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Classes {

  abstract class AbstractFactory {
    public abstract AbstractWater CreateWater();
    public abstract AbstractBottle CreateBottle();
  }

  abstract class AbstractWater {
  }

  abstract class AbstractBottle {
    public abstract void Interact(AbstractWater water);
  }
}
