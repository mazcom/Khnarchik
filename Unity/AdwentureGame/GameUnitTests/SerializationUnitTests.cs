using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using AdventureGame.Domain;
using AdventureGame.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GameUnitTests {
  [TestClass]
  public class SerializationUnitTests {
    
    [TestMethod]
    public void SerializeDessirializeTest1() {

      List<State> states = new List<State>();

      states.Add(new State() {Title = "Start Point", Description = "Here you start your adventure" });
      states.Add(new State() {Title = "A Wood", Description = "Let's entrance into the wood" });
      
      // remove:
      //states[1].Transitions.Add(new Transition() { To = states[0] });

      JsonSerializer serializer = new JsonSerializer();
      serializer.NullValueHandling = NullValueHandling.Include;
      serializer.Formatting = Formatting.Indented;

      Stream stream = new MemoryStream();
      try {

        // Serialize to memory
        using (StreamWriter sw = new StreamWriter(stream,encoding: Encoding.Default,  bufferSize: 512, leaveOpen: true))
        using (JsonWriter writer = new JsonTextWriter(sw)) {
          serializer.Serialize(writer, states);
        }

        // Deserialize from memory
        stream.Position = 0;

        // remove:
        //StreamReader reader = new StreamReader(stream, encoding: Encoding.Default, detectEncodingFromByteOrderMarks:true, bufferSize: 512, leaveOpen: true);
        //string text = reader.ReadToEnd();
        //reader.Close();
        //stream.Position = 0;


        using (var sr = new StreamReader(stream))
        using (var jsonTextReader = new JsonTextReader(sr)) {
          //var states2 = JsonConvert.DeserializeObject()
            var sdsd= (List<State>)serializer.Deserialize(jsonTextReader, typeof(List<State>));
        }


      }
      finally {
        stream.Dispose();
      }
    }

    [TestMethod]
    public void SerializeDessirializeTest2() {

      //List<State> states = new List<State>();

      //states.Add(new State() {Id= Guid.NewGuid(), Title = "Start Point", Description = "Here you start your adventure" });
      //states.Add(new State() { Id = Guid.NewGuid(), Title = "A Wood", Description = "Let's entrance into the wood" });
      //states[1].Transitions.Add(new Transition() { To = states[0] });


      //JsonSerializer serializer = new JsonSerializer();
      //serializer.NullValueHandling = NullValueHandling.Include;
      //serializer.Formatting = Formatting.Indented;

      //using(FileStream fs = File.Create(@"E:\3\data.json"))
      //using (StreamWriter sw = new StreamWriter(fs))
      //using (JsonWriter jw = new JsonTextWriter(sw)) {
      //  jw.Formatting = Formatting.Indented;
      
      //  serializer.Serialize(jw, states);
      //}
    }

    [TestMethod]
    public void SerializeDessirializeTest3() {

      List<State> states = new List<State>();
      states.Add(new State() {Id= Guid.NewGuid(), Number = 15,  Title = "Start Point", Description = "Here you start your adventure" });
      states.Add(new State() { Id = Guid.NewGuid(), Number = 200,  Title = "A Wood", Description = "Let's entrance into the wood" });
      states[1].Transitions.Add(new Transition() { To = states[0] });

      StateRepository repository = new StateRepository(@"E:\3\data.json");

      foreach (var state in states)
        repository.Add(state);

      repository.SaveChanges();
    }

    [TestMethod]
    public void SerializeDessirializeTest4() {

      StateRepository repository = new StateRepository(@"E:\3\data.json");
      var list = repository.GetAll().ToList();
      
    }
  }
}
