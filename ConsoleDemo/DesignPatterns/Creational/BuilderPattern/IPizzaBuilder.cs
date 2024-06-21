namespace ConsoleDemo.DesignPatterns.Creational.BuilderPattern;
public interface IPizzaBuilder
{
  void BuildPartA();
  void BuildPartB();
  Product GetResult();
}
