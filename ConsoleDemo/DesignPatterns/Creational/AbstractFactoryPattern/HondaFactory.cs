namespace ConsoleDemo.DesignPatterns.Creational.AbstractFactory;

public class HondaFactory : IVehicleFactory
{
  public IBike CreateBike()
  {
    return new HondaBike();
  }

  public ICar CreateCar()
  {
    return new ToyotaCar();
  }
}