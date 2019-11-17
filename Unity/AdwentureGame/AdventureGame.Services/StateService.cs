using AdventureGame.Domain.Core;
using System;
using System.Collections.Generic;

namespace AdventureGame.Services {

  public class StateService : IStateService {

    private readonly IRepository<State> statesRepository;

    public StateService(IRepository<State> statesRepository) {

      this.statesRepository = statesRepository;
    }

    public IEnumerable<State> GetStates() {

      return statesRepository.List();
    }

    public State GetState(long id) {
      throw new NotImplementedException();
    }

    public void AddState(State state) {

      statesRepository.Add(state);
      statesRepository.SaveChanges();
    }

    public void DeleteState(State state) {

      var allStates = statesRepository.List();

      // Remove Related Transitions
      foreach (var s in allStates)
        s.Transitions.RemoveAll(t => t.To == state);

      statesRepository.Delete(state);
      statesRepository.SaveChanges();
    }

    public void UpdateState(State state) {

      statesRepository.Update(state);
      statesRepository.SaveChanges();
    }
  }
}
