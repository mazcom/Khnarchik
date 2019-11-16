using GameModel.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AdventureGame.ViewModels.ViewModels {

  public class MainViewModel {

    public MainViewModel(List<State> states) {

      States = new ObservableCollection<State>(states);
    }

    public ObservableCollection<State> States {
      get;
    }

    public State CurrentState {
      get;
      set;
    }

    public void CreateNewState() {

      var newState = new State();
      States.Add(newState);
    }

    public void DeleteState(State state) {

      States.Remove(state);
    }
  }
}
