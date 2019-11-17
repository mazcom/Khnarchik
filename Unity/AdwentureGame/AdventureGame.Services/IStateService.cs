using AdventureGame.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Services {

  public interface IStateService {

    IEnumerable<State> GetStates();
    State GetState(long id);
    void AddState(State state);
    void UpdateState(State state);
    void DeleteState(State state);
  }
}
