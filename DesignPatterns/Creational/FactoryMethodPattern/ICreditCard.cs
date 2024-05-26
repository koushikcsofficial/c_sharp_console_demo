namespace DesignPatterns.Creational.FactoryMethodPattern;

// Step 1: Define the Product (CreditCard) interface
interface ICreditCard
{
  string GetCardType();
  double GetCreditLimit();
  double GetAnnualCharge();
}