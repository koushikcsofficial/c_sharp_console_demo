namespace ConsoleDemo.DesignPatterns.Creational.BuilderPattern;
// Director class coordinates the building process
public class Director
{
  private readonly IPizzaBuilder _builder;

  public Director(IPizzaBuilder builder)
  {
    _builder = builder;
  }

  public void Construct()
  {
    _builder.BuildPartA(); // Build crust
    _builder.BuildPartB(); // Add toppings
  }
}
