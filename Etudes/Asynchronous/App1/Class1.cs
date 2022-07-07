using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Class1
    {

        public void RotateMatrices(IEnumerable<int> items)
        {
            Parallel.ForEach(items, i => { Thread.Sleep(i);  Console.WriteLine($"{i}"); });
        }

        public async Task DoSomethingAsync()
        {
            Console.WriteLine("before async");

            int value = 13;
            // Asynchronously wait 1 second.
            await Task.Delay(TimeSpan.FromSeconds(2));

            Console.WriteLine($"thread between: { Thread.CurrentThread.ManagedThreadId}");
            value *= 2;
            Console.WriteLine("between");
            // Asynchronously wait 1 second.
            await Task.Delay(TimeSpan.FromSeconds(2));
            Trace.WriteLine(value);

            Console.WriteLine($"thread after: { Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine("after async");
        }

        public void M1()
        {

        } 
    }
}
