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
        //Assert.IsTrue(states.SequenceEqual(repoStates));

      }
      finally {
        stream.Dispose();
      }
    }
  }
}
