﻿using AdventureGame.Domain;
using AdventureGame.Domain.Interfaces;
using AdventureGame.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.UnitTests.Service {

  [TestClass]
  public class CountryServiceTest {

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

      var state1 = new State() { Id = 10, Title = "Tavern"};
      var state2 = new State() { Id = 115, Title = "Field" };
      var state3 = new State() { Id = 8, Title = "Wood" };
      var state4 = new State() { Id = 2, Title = "Table" };
      var state5 = new State() { Id = 33, Title = "Trunk", Description = "You wake up as the sun..." };

      state1.Transitions.Add(new Transition() {To = state2, Name = "Trans1" });
      state1.Transitions.Add(new Transition() { To = state5, Name = "Trans1" });
      state2.Transitions.Add(new Transition() { To = state3, Name = "Trans3" });
      state4.Transitions.Add(new Transition() { To = state5, Name = "Trans4" });
      state3.Transitions.Add(new Transition() { To = state5, Name = "Trans5" });

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
        Id = 111,
        Title = "wizard"
      };

      // set up the repository’s Delete call
      mockRepository.Setup(r => r.Delete(It.IsAny<State>()));

      // Act
      service.AddState(state);

      // Assert
      // verify that the Add method we set up above was called
      // with the state as the first argument
      mockRepository.Verify(r => r.Add(state));
    }

    [TestMethod]
    public void AddState2() {

      var newState = new State() {
        Id = 222,
        Title = "Master of Garden"
      };

      // Arrange
      mockRepository.Setup(r => r.Add(It.IsAny<State>())).Callback((State state) => listStates.Add(state));

      // Act
      service.AddState(newState);

      // Assert
      Assert.AreEqual(listStates.Count, 6);
      Assert.IsTrue(listStates.Exists(s => s.Id == newState.Id));
    }

    [TestMethod]
    public void DeleteState() {

      // Arrange
      var state = new State() {
        Id = 111,
        Title = "wizard"
      };

      // set up the repository’s Delete call
      mockRepository.Setup(r => r.Delete(It.IsAny<State>()));

      // Act
      service.DeleteState(state);

      // Assert
      // verify that the Delete method we set up above was called
      // with the state as the first argument
      mockRepository.Verify(r => r.Delete(state));
    }

    [TestMethod]
    public void DeleteState2() {

      int stateIdToDelete = 33;

      // Arrange
      mockRepository.Setup(x => x.GetAll()).Returns(listStates);
      mockRepository.Setup(x => x.GetById(stateIdToDelete)).Returns(listStates.First(s=> s.Id == stateIdToDelete));
      mockRepository.Setup(r => r.Delete(It.IsAny<State>())).Callback((State state) => listStates.Remove(state));

      // Act
      service.DeleteState(mockRepository.Object.GetById(stateIdToDelete));

      // Assert
      Assert.AreEqual(listStates.Count, 4);
      Assert.AreEqual(listStates.First(s=> s.Id == 10).Transitions.Count, 1);
      Assert.AreEqual(listStates.First(s => s.Id == 2).Transitions.Count, 0);
      Assert.AreEqual(listStates.First(s => s.Id == 8).Transitions.Count, 0);
      Assert.IsTrue(!listStates.Exists(s=> s.Id == stateIdToDelete));
    }

    [TestMethod]
    public void UpdateState() {

      // Arrange
      var state = new State() {
        Id = 111,
        Title = "wizard"
      };

      // set up the repository’s Delete call
      mockRepository.Setup(r => r.Delete(It.IsAny<State>()));

      // Act
      service.UpdateState(state);

      // Assert
      // verify that the Update method we set up above was called
      // with the state as the first argument
      mockRepository.Verify(r => r.Update(state));
    }

    [TestMethod]
    public void UpdateState2() {

      string newTitle = "Tower";
      string newDesciption = "You have chosen...";
      int stateIdToUpdate = 33;

      // Arrange
      // set up the repository’s Delete call
      mockRepository.Setup(r => r.Delete(It.IsAny<State>()));
      mockRepository.Setup(x => x.GetById(stateIdToUpdate)).Returns(listStates.First(s => s.Id == stateIdToUpdate));

      // Act
      State state = mockRepository.Object.GetById(stateIdToUpdate);
      state.Title = newTitle;
      state.Description = newDesciption;
      service.UpdateState(state);

      // Assert
      Assert.IsTrue(listStates.First(s => s.Id == stateIdToUpdate).Title == newTitle);
      Assert.IsTrue(listStates.First(s => s.Id == stateIdToUpdate).Description == newDesciption);
    }
  }
}
