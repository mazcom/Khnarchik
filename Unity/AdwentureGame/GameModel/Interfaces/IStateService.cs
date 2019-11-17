using AdventureGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Domain {

  public interface IStateService {

    IEnumerable<State> GetAll();
    State GetState(int id);
    void AddState(State state);
    void UpdateState(State state);
    void DeleteState(State state);
  }
}
