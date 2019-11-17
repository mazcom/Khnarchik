using AdventureGame.Domain;
using AdventureGame.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace AdventureGame.Services {

  public class StateService : IStateService {

    private readonly IStateRepository statesRepository;

    public StateService(IStateRepository statesRepository) {

      this.statesRepository = statesRepository;
    }

    public IEnumerable<State> GetAll() {

      return statesRepository.GetAll();
    }

    public State GetState(int id) {

      return statesRepository.GetById(id);
    }

    public void AddState(State state) {

      statesRepository.Add(state);
      statesRepository.SaveChanges();
    }

    public void DeleteState(State state) {

      var allStates = statesRepository.GetAll();

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
