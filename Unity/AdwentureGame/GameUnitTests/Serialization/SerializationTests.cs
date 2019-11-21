using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using AdventureGame.Domain;
using AdventureGame.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Runtime.InteropServices.ComTypes;
using KellermanSoftware.CompareNetObjects;

namespace GameUnitTests {
  [TestClass]
  public class SerializationTests {

    [TestMethod]
    public void CheckStatesSchema1() {

      // Arrange
      List<State> states = new List<State>();
      states.Add(new State() { Id = Guid.NewGuid(), Number = 1, Title = "Start Point", Description = "Here you start your adventure" });
      
      Stream stream = new MemoryStream();

      try {

        // Act
        JsonStateRepository repo = new JsonStateRepository(stream);

        foreach (var state in states)
          repo.Add(state);
        
        repo.SaveChanges();
        List<State> repoStates = repo.GetAll().ToList();

        // Assert
        CompareLogic comparer = new CompareLogic();
        Assert.IsTrue(comparer.Compare(states, repoStates).AreEqual);
      }
      finally {
        stream.Dispose();
      }
    }

    [TestMethod]
    public void CheckStatesSchema2() {

      // Arrange
      List<State> states = new List<State>();
      states.Add(new State() { Id = Guid.NewGuid(), Number = 15, Title = "Start Point", Description = "Here you start your adventure" });
      states.Add(new State() { Id = Guid.NewGuid(), Number = 200, Title = "A Wood", Description = "Let's entrance into the wood" });
      states[1].Transitions.Add(new Transition() { To = states[0] });

      Stream stream = new MemoryStream();

      try {

        // Act
        JsonStateRepository repo = new JsonStateRepository(stream);

        foreach (var state in states)
          repo.Add(state);

        repo.SaveChanges();
        List<State> repoStates = repo.GetAll().ToList();

        // Assert
        CompareLogic comparer = new CompareLogic();
        Assert.IsTrue(comparer.Compare(states, repoStates).AreEqual);
      }
      finally {
        stream.Dispose();
      }
    }

    [TestMethod]
    public void CheckStatesSchema3() {

      // Arrange
      List<State> states = new List<State>();
      states.Add(new State() { Id = Guid.NewGuid(), Number = 15, Title = "Start Point", Description = "Here you start your adventure" });
      states.Add(new State() { Id = Guid.NewGuid(), Number = 200, Title = "A Wood", Description = "Let's entrance into the wood" });
      states[1].Transitions.Add(new Transition() { To = states[0], Name = "forward" });
      states[0].Transitions.Add(new Transition() { To = states[1], Name = "back" });

      Stream stream = new MemoryStream();

      try {

        // Act
        JsonStateRepository repo = new JsonStateRepository(stream);

        foreach (var state in states)
          repo.Add(state);

        repo.SaveChanges();
        List<State> repoStates = repo.GetAll().ToList();

        // Assert
        CompareLogic comparer = new CompareLogic();
        Assert.IsTrue(comparer.Compare(states, repoStates).AreEqual);
      }
      finally {
        stream.Dispose();
      }
    }


  }
}
