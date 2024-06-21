namespace ConsoleDemo.DesignPatterns.Creational.BuilderPattern;
public class HawaiianPizzaBuilder : IPizzaBuilder
{
  private Product _pizza = new Product();

  public void BuildPartA()
  {
    _pizza.PartA = "Thin crust";
  }

  public void BuildPartB()
  {
    _pizza.PartB = "Pineapple and ham toppings";
  }

  public Product GetResult()
  {
    return _pizza;
  }
}
