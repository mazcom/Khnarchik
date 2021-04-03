using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransmitterReceiver;

namespace ConsoleApp {
  class Program {
    static void Main(string[] args) {


      // Transmitter
      Task task = Task.Run(() => {

        Transmitter transmitter = new Transmitter();
        var session = transmitter.CreatSession();

        while (true) {
          var doc = transmitter.CreateDocument(session);
          Thread.Sleep(1000);
        }
      });


      // Receiver
      Task task2 = Task.Run(() => {

        Receiver receiver = new Receiver();

        while (true) {

          Console.Clear();
          Console.WriteLine("The list of the documents:");
          var documents = receiver.GetDocuments();
          foreach (var doc in documents) {
            Console.WriteLine($"doc: id ={doc.Number}");
          }
          Thread.Sleep(1000);
        }
      });

      Console.ReadKey();
    }
  }
}
