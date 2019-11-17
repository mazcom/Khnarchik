using AdventureGame.Domain;
using AdventureGame.Domain.Interfaces;
using AdventureGame.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

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
      listStates = new List<State>() {
           new State() { Id = 10, Title = "Tavern" },
           new State() { Id = 115, Title = "Field" },
           new State() { Id = 8, Title = "Wood" },
           new State() { Id = 2, Title = "Table" },
           new State() { Id = 33, Title = "Trunk" }
          };
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

      int stateId = 10;

      // Arrange
      mockRepository.Setup(x => x.GetAll()).Returns(listStates);
      mockRepository.Setup(x => x.GetById(stateId)).Returns(listStates[0]);
      mockRepository.Setup(r => r.Delete(It.IsAny<State>())).Callback((State state) => listStates.Remove(state));

      // Act
      service.DeleteState(mockRepository.Object.GetById(stateId));

      // Assert
      Assert.AreEqual(listStates.Count, 4);
    }
  }
}
