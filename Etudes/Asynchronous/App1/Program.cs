using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var sss = SynchronizationContext.
            Console.WriteLine("hello");
            //await TestAsync();
            

            await foreach (int value in GetValuesAsync())
            {
                await Task.Delay(1000).ConfigureAwait(false); // asynchronous work
                Console.WriteLine(value);
            }
            //Task task1 = Task.Delay(TimeSpan.FromSeconds(1));
            //Task task2 = Task.Delay(TimeSpan.FromSeconds(2));
            //Task task3 = Task.Delay(TimeSpan.FromSeconds(1));
            //await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("end");

        }

        static async IAsyncEnumerable<int> GetValuesAsync()
        {
            await Task.Delay(3000); // some asynchronous work
            yield return 10;
            await Task.Delay(3000); // more asynchronous work
            yield return 13;
        }


        static async Task ThrowExceptionAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            //throw new InvalidOperationException("Test");
        }
        static async Task TestAsync()
        {
            // The exception is thrown by the method and placed on the task.
            Task task = ThrowExceptionAsync();

            await task;
            try
            {
                // The exception is re-raised here, where the task is awaited.
                await task;
            }
            catch (InvalidOperationException)
            {
                // The exception is correctly caught here.
            }
        }
    }
}
