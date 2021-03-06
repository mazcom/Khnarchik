﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Domain {

  public class State : BaseEntity {

    public State() {

      Transitions = new List<Transition>();
    }

    /// <summary>
    /// A logical unique number of a state. It likes a page or so one.
    /// </summary>
    public int Number {
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
    public List<Transition> Transitions {
      get;
      set;
    }
  }
}
