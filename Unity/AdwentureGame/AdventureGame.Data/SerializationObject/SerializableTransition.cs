using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Infrastructure {

  public class SerializableTransition {

    public string Name {
      get;
      set;
    }

    public Guid To {
      get;
      set;
    }
  }
}
