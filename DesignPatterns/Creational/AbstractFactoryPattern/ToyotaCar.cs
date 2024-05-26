namespace DesignPatterns.Creational.AbstractFactory;

public class ToyotaCar : ICar
{
  public void CreateCar()
  {
    Console.WriteLine("Toyota Car created!");
  }
}