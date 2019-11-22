using AdventureGame.Domain;
using System.Collections.ObjectModel;

namespace AdventureGame.ViewModels {

  public class MainViewModel {

    //private IStateRepository stateRepository;

    public MainViewModel(IStateRepository stateRepository) {

      States = new ObservableCollection<State>(stateRepository.GetAll());
    }

    public ObservableCollection<State> States {
      get;
    }

    //public State CurrentState {
    //  get;
    //  set;
    //}

    //public void CreateNewState() {

    //  var newState = new State();
    //  States.Add(newState);
    //}

    //public void DeleteState(State state) {

    //  States.Remove(state);
    //}
  }
}
