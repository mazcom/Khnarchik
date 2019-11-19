using AdventureGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Infrastructure {
  
  public class SerializableState {

    public SerializableState() {

      Transitions = new List<SerializableTransition>();
    }

    public Guid Id {
      get;
      set;
    }

    public int Number {
      get;
      set;
    }

    public Guid SerialisationKey {
      get;
      set;
    }

    /// <summary>
    /// A short discription of a state.
    /// </summary>
    public string Title {
      get;
      set;
    }

    /// <summary>
    /// A description of a state.
    /// </summary>
    public string Description {
      get;
      set;
    }

    /// <summary>
    /// The transitions
    /// </summary>
    public List<SerializableTransition> Transitions {
      get;
      set;
    }
  }
}
