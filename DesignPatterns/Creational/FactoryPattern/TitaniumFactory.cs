namespace DesignPatterns.Creational.FactoryPattern;

class TitaniumFactory : ICreditCardFactory
{
  public ICreditCard CreateCreditCard() => new Titanium();
}