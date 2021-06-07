using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverDesignPattern
{
  class Program
  {
    static void Main(string[] args)
    {

      var provider = new TemperatureProvider();

      var observer1 = new TemperatureObserver("observer1");
      var observer2 = new TemperatureObserver("observer2");

      IDisposable token1 = provider.Subscribe(observer1);
      IDisposable token2 = provider.Subscribe(observer2);

      var info1 = new TemperatureInfo() { Temperature = 25, Description = "Good temprerature" };
      var info2 = new TemperatureInfo() { Temperature = 5, Description = "Cold temprerature" };
      var info3 = new TemperatureInfo() { Temperature = 20, Description = "Average temprerature" };

      provider.Notify(info1);
      Console.WriteLine("---");

      Thread.Sleep(1500);
      provider.Notify(info2);
      Console.WriteLine("---");

      Thread.Sleep(1500);
      token1.Dispose();
      provider.Notify(info3);

      Console.ReadKey();
    }
  }


  class TemperatureObserver : IObserver<TemperatureInfo>
  {

    private readonly string name;

    public TemperatureObserver(string name)
    {
      this.name = name;
    }


    // Вызывается в том случае, если уведомлений больше не будет.
    public void OnCompleted()
    {

      throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {

      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine($"Observer Name: {name} received error {error.Message}");
      Console.ResetColor();
    }

    // Будет вызван, когда поступит новая инфа.
    public void OnNext(TemperatureInfo value)
    {
      Console.WriteLine($"Observer Name: {name} received temperature {value.Temperature}");
    }
  }

  class TemperatureProvider : IObservable<TemperatureInfo>
  {

    List<IObserver<TemperatureInfo>> observers;

    public TemperatureProvider()
    {

      observers = new List<IObserver<TemperatureInfo>>();
    }

    public IDisposable Subscribe(IObserver<TemperatureInfo> observer)
    {
      observers.Add(observer);
      return new Unsubscriber<TemperatureInfo>(observers, observer);
    }

    public void Notify(TemperatureInfo info)
    {
      foreach (var observer in observers)
      {
        observer.OnNext(info);
      }
    }
  }

  public class TemperatureInfo
  {

    public int Temperature { get; set; }
    public string Description { get; set; }
  }

  public sealed class Unsubscriber<TypeDefinition> : IDisposable
  {
    private readonly List<IObserver<TypeDefinition>> observers;
    private readonly IObserver<TypeDefinition> observer;

    public Unsubscriber(List<IObserver<TypeDefinition>> observers, IObserver<TypeDefinition> observer)
    {
      this.observers = observers;
      this.observer = observer;
    }

    public void Dispose()
    {
      observers.Remove(observer);
    }
  }

}
