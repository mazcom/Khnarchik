using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Domain {

  public class Transition {

    public Transition() {

    }

    public string Name {
      get; 
      set;
    }

    public State To {
      get; 
      set;
    }
  }
}
