using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GameModel.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace GameUnitTests {
  [TestClass]
  public class SerializationUnitTests {
    
    [TestMethod]
    public void SerializeDessirializeTest1() {

      List<State> states = new List<State>();

      states.Add(new State() { UniqueNumber = 1, Title = "Start Point", Text = "Here you start your adventure" });
      states.Add(new State() { UniqueNumber = 5,  Title = "A Wood", Text = "Let's entrance into the wood" });

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
  }
}
