using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disposable {
  
  class Program {
    static void Main(string[] args) {

      for (int i = 0; i < 100000; i++) {
        Do();
        Console.WriteLine($"line {i}");
      }
      Console.ReadKey();
    }

    static void Do() {

      var test = new Test(); // lets finalizer work

      //using (var test2 = new Test()) {  // doesnt let finalizer work
      //}
    }
  }

  class Test : IDisposable {

    public void Dispose() // NOT virtual
    {
      Dispose(true);
      GC.SuppressFinalize(this); // Prevent finalizer from running.
    }
    protected virtual void Dispose(bool disposing) {
      if (disposing) {
        // Call Dispose() on other objects owned by this instance.
        // You can reference other finalizable objects here.
        // ...
      }
      // Release unmanaged resources owned by (just) this object.
      // ...
    }
    ~Test() => Dispose(false);
  }

  /*
   Standard Disposal Semantics
    .NET follows a de facto set of rules in its disposal logic. These rules are not hardwired
    to .NET or the C# language in any way; their purpose is to define a consistent
    protocol to consumers. Here they are:
    
    1. After an object has been disposed, it’s beyond redemption. It cannot be reactivated,
    and calling its methods or properties (other than Dispose) throws an
    ObjectDisposedException.
    
    2. Calling an object’s Dispose method repeatedly causes no error.
    
    3. If disposable object x “owns” disposable object y, x’s Dispose method automatically
    calls y’s Dispose method—unless instructed otherwise.
   */

  /*
    Notice that we call GC.SuppressFinalize in the parameterless Dispose method—
    this prevents the finalizer from running when the GC later catches up with it. Technically,
    this is unnecessary given that Dispose methods must tolerate repeated calls.
    However, doing so improves performance because it allows the object (and its referenced
    objects) to be garbage collected in a single cycle.
   */
}
