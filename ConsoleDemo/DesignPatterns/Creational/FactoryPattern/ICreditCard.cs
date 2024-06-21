namespace ConsoleDemo.DesignPatterns.Creational.FactoryPattern;

// Step 1: Define the Product (CreditCard) interface
interface ICreditCard
{
  string GetCardType();
  double GetCreditLimit();
  double GetAnnualCharge();
}