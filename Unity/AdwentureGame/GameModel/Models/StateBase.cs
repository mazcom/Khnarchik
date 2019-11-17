﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Domain.Core {

  public abstract class StateBase {

    /// <summary>
    /// An unique number of a state
    /// </summary>
    public int Id {
      get; 
      private set;
    }
  }
}
