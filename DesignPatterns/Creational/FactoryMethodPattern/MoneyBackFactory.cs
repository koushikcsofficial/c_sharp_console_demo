namespace DesignPatterns.Creational.FactoryMethodPattern;

// Step 4: Create Concrete Creators (MoneyBackFactory, TitaniumFactory, PlatinumFactory)
class MoneyBackFactory : CreditCardFactory
{
  public override ICreditCard CreateCreditCard() => new MoneyBack();
}