using AdventureGame.Domain;
using AdventureGame.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.UnitTests.Service {

  [TestClass]
  public class StatesServiceTest {

    private Mock<IStateRepository> mockRepository;
    private IStateService service;
    private List<State> listStates;

    /// <summary>
    /// TestInitialize and TestCleanup are ran before and after each test, 
    /// this is to ensure that no tests are coupled.
    /// </summary>
    [TestInitialize]
    public void Initialize() {

      mockRepository = new Mock<IStateRepository>();
      service = new StateService(mockRepository.Object);

      listStates = new List<State>();

      var state1 = new State() { Id = Guid.Parse("0a3715b6-97a9-4721-9212-af96a292c88e"), Title = "Tavern"};
      var state2 = new State() { Id = Guid.Parse("f79b8ec7-c64d-4c83-a4c8-ed8e0b1802b7"), Title = "Field" };
      var state3 = new State() { Id = Guid.Parse("e4b37167-cd8a-4927-a330-4d8692111d71"), Title = "Wood" };
      var state4 = new State() { Id = Guid.Parse("d3e3757c-b080-4851-b1a5-18e91222de9b"), Title = "Table" };
      var state5 = new State() { Id = Guid.Parse("3a6d9539-527e-4377-9e3f-aa875b2147cc"), Title = "Trunk", Description = "You wake up as the sun..." };

      state1.Transitions.Add(new Transition() {To = state2, Name = "Trans1" });
      state1.Transitions.Add(new Transition() { To = state5, Name = "Trans1" });
      state2.Transitions.Add(new Transition() { To = state3, Name = "Trans3" });
      state3.Transitions.Add(new Transition() { To = state5, Name = "Trans5" });
      state4.Transitions.Add(new Transition() { To = state5, Name = "Trans4" });

      listStates.Add(state1);
      listStates.Add(state2);
      listStates.Add(state3);
      listStates.Add(state4);
      listStates.Add(state5);
    }

    [TestMethod]
    public void GetAllStates() {

      // Arrange
      mockRepository.Setup(x => x.GetAll()).Returns(listStates);

      // Act
      List<State> results = service.GetAll() as List<State>;

      // Assert
      Assert.IsNotNull(results);
      Assert.AreEqual(5, results.Count);
    }

    [TestMethod]
    public void AddState() {

      // Arrange
      var state = new State() {
        Id = Guid.NewGuid(),
        Title = "wizard"
      };

      // set up the repository’s Delete call
      mockRepository.Setup(r => r.Delete(It.IsAny<State>()));

      // Act
      service.Add(state);

      // Assert
      // verify that the Add method we set up above was called
      // with the state as the first argument
      mockRepository.Verify(r => r.Add(state));
    }

    [TestMethod]
    public void AddState2() {

      var newState = new State() {
        Id = Guid.NewGuid(),
        Title = "Master of Garden"
      };

      // Arrange
      mockRepository.Setup(r => r.Add(It.IsAny<State>())).Callback((State state) => listStates.Add(state));

      // Act
      service.Add(newState);

      // Assert
      Assert.AreEqual(listStates.Count, 6);
      Assert.IsTrue(listStates.Exists(s => s.Id == newState.Id));
    }

    [TestMethod]
    public void DeleteState() {

      // Arrange
      var state = new State() {
        Id = Guid.NewGuid(),
        Title = "wizard"
      };

      // set up the repository’s Delete call
      mockRepository.Setup(r => r.Delete(It.IsAny<State>()));

      // Act
      service.Delete(state);

      // Assert
      // verify that the Delete method we set up above was called
      // with the state as the first argument
      mockRepository.Verify(r => r.Delete(state));
    }

    [TestMethod]
    public void DeleteState2() {

      Guid stateIdToDelete = Guid.Parse("3a6d9539-527e-4377-9e3f-aa875b2147cc");

      // Arrange
      mockRepository.Setup(x => x.GetAll()).Returns(listStates);
      mockRepository.Setup(x => x.GetById(stateIdToDelete)).Returns(listStates.First(s=> s.Id == stateIdToDelete));
      mockRepository.Setup(r => r.Delete(It.IsAny<State>())).Callback((State state) => listStates.Remove(state));

      // Act
      service.Delete(mockRepository.Object.GetById(stateIdToDelete));

      // Assert
      Assert.AreEqual(listStates.Count, 4);
      Assert.AreEqual(listStates.First(s=> s.Id == Guid.Parse("0a3715b6-97a9-4721-9212-af96a292c88e")).Transitions.Count, 1);
      Assert.AreEqual(listStates.First(s => s.Id == Guid.Parse("e4b37167-cd8a-4927-a330-4d8692111d71")).Transitions.Count, 0);
      Assert.AreEqual(listStates.First(s => s.Id == Guid.Parse("d3e3757c-b080-4851-b1a5-18e91222de9b")).Transitions.Count, 0);
      Assert.IsTrue(!listStates.Exists(s=> s.Id == stateIdToDelete));
    }

    [TestMethod]
    public void UpdateState() {

      // Arrange
      var state = new State() {
        Id = Guid.Parse("f79b8ec7-c64d-4c83-a4c8-ed8e0b1802b7"),
        Title = "wizard"
      };

      // set up the repository’s Delete call
      mockRepository.Setup(r => r.Delete(It.IsAny<State>()));

      // Act
      service.Update(state);

      // Assert
      // verify that the Update method we set up above was called
      // with the state as the first argument
      mockRepository.Verify(r => r.Update(state));
    }

    [TestMethod]
    public void UpdateState2() {

      string newTitle = "Tower";
      string newDesciption = "You have chosen...";
      Guid stateIdToUpdate = Guid.Parse("f79b8ec7-c64d-4c83-a4c8-ed8e0b1802b7");

      // Arrange
      // set up the repository’s Delete call
      mockRepository.Setup(r => r.Delete(It.IsAny<State>()));
      mockRepository.Setup(x => x.GetById(stateIdToUpdate)).Returns(listStates.First(s => s.Id == stateIdToUpdate));

      // Act
      State state = mockRepository.Object.GetById(stateIdToUpdate);
      state.Title = newTitle;
      state.Description = newDesciption;
      service.Update(state);

      // Assert
      Assert.IsTrue(listStates.First(s => s.Id == stateIdToUpdate).Title == newTitle);
      Assert.IsTrue(listStates.First(s => s.Id == stateIdToUpdate).Description == newDesciption);
    }
  }
}
