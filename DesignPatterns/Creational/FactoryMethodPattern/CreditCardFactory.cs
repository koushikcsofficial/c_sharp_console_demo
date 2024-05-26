namespace DesignPatterns.Creational.FactoryMethodPattern;

// Step 3: Create an Abstract Creator (CreditCardFactory)
abstract class CreditCardFactory
{
  public abstract ICreditCard CreateCreditCard();
}