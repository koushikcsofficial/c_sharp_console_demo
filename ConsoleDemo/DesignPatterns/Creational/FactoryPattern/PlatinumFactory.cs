namespace ConsoleDemo.DesignPatterns.Creational.FactoryPattern;

// Step 4: Create Concrete Creators (PlatinumFactory, MoneyBackFactory, TitaniumFactory)
class PlatinumFactory : ICreditCardFactory
{
  public ICreditCard CreateCreditCard() => new Platinum();
}