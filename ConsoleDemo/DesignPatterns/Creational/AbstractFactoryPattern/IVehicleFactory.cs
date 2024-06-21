namespace ConsoleDemo.DesignPatterns.Creational.AbstractFactory;

public interface IVehicleFactory
{
  IBike CreateBike();
  ICar CreateCar();
}