namespace DesignPatterns.Creational.FactoryPattern;

class MoneyBackFactory : ICreditCardFactory
{
  public ICreditCard CreateCreditCard() => new MoneyBack();
}