using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Domain {

  public abstract class BaseEntity {

    /// <summary>
    /// An unique number of entity
    /// </summary>
    public Guid Id {
      get; 
      set;
    }
  }
}
