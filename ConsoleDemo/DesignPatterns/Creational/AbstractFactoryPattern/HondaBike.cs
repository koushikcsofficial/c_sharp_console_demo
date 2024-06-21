namespace ConsoleDemo.DesignPatterns.Creational.AbstractFactory;

public class HondaBike : IBike
{
  public void CreateBike()
  {
    Console.WriteLine("Honda Bike created!");
  }
}