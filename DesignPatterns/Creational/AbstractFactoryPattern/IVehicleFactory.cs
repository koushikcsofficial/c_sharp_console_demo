namespace DesignPatterns.Creational.AbstractFactory;

public interface IVehicleFactory
{
  IBike CreateBike();
  ICar CreateCar();
}