using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Domain.Core {

  public class State : StateBase {

    public State() {

      Transitions = new List<Transition>();
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
    public string Text {
      get;
      set;
    }

    /// <summary>
    /// The transitions
    /// </summary>
    public List<Transition> Transitions {
      get;
      set;
    }
  }
}
