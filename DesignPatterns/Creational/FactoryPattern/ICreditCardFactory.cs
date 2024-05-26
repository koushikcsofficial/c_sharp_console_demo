namespace DesignPatterns.Creational.FactoryPattern;

// Step 3: Create an Abstract Creator (CreditCardFactory)
interface ICreditCardFactory
{
  ICreditCard CreateCreditCard();
}