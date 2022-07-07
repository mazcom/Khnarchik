using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
  class Program
  {
    static void Main(string[] args)
    {
      List<int> list = new List<int> { 1, 2, 3 };
      while (list.Count < 1000)
      {
        list.Add(0);
      }
      Thread t1 = new Thread(() => Do(list));
      t1.Start();
      Thread t2 = new Thread(() => Do2(list));
      t2.Start();

      t1.Join();
      t2.Join();

      Console.WriteLine("{0,-25} {1}", "Name2222222111111111111111111111111111", "Hours111111111111");
      Console.WriteLine("{0,-25} {1}", "Name", "Hours11");

      BlockingCollection<int> _blockingStack = new BlockingCollection<int>(new ConcurrentStack<int>());

      // Producer code
      _blockingStack.Add(7);
      _blockingStack.Add(13);
      _blockingStack.CompleteAdding();

      // Consumer code
      // Displays "13" followed by "7".
      foreach (int item in _blockingStack.GetConsumingEnumerable())
        Console.WriteLine(item);

      Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: End");
    }

    private static void Do(List<int> list)
    {
      try
      {
        while (list.Count > 1)
        {
          list.RemoveAt(0);
        }
        //foreach (var item in list)
        //{
        //  //list[2] = 5;
        //  Console.WriteLine(item);
        //}
      }
      catch(Exception ex)
      {

      }
    }

    private static void Do2(List<int> list)
    {
      try
      {
        while (list.Count > 1)
        {
          list.RemoveAt(0);
        }
        //foreach (var item in list)
        //{
        //  Console.WriteLine(item);
        //}
      }
      catch (Exception ex)
      {

      }
    }
  }

  //class Program
  //{
  //    static async Task Main(string[] args)
  //    {
  //        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Start");
  //        await foreach (var item in FetchItems())
  //        {
  //            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
  //        }
  //        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: End");
  //    }

  //    static async IAsyncEnumerable<int> FetchItems()
  //    {
  //        for (int i = 1; i <= 10; i++)
  //        {
  //            await Task.Delay(1000);
  //            yield return i;
  //        }
  //    }
  //}

  //class Program
  //{
  //    static async Task Main(string[] args)
  //    {
  //        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: Start");
  //        foreach (var item in await FetchItems())
  //        {
  //            Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: {item}");
  //        }
  //        Console.WriteLine($"{DateTime.Now.ToLongTimeString()}: End");
  //    }
  //    static async Task<IEnumerable<int>> FetchItems()
  //    {
  //        List<int> Items = new List<int>();
  //        for (int i = 1; i <= 10; i++)
  //        {
  //            await Task.Delay(1000);
  //            Items.Add(i);
  //        }
  //        return Items;
  //    }
  //}
}
