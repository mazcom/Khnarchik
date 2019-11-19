using AdventureGame.Domain;
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

    public State GetState(Guid id) {

      return statesRepository.GetById(id);
    }

    public void Add(State state) {

      statesRepository.Add(state);
      statesRepository.SaveChanges();
    }

    public void Delete(State state) {

      // Remove Related Transitions
      foreach (var s in statesRepository.GetAll())
        s.Transitions.RemoveAll(t => t.To == state);

      statesRepository.Delete(state);
      statesRepository.SaveChanges();
    }

    public void Update(State state) {

      statesRepository.Update(state);
      statesRepository.SaveChanges();
    }
  }
}
