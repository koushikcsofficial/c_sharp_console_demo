namespace DesignPatterns.Creational.AbstractFactory;

public class ToyotaFactory : IVehicleFactory
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