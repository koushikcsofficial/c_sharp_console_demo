namespace ConsoleDemo.DesignPatterns.Creational.FactoryMethodPattern;

// Step 2: Create Concrete Products (MoneyBack, Titanium, Platinum)
class MoneyBack : ICreditCard
{
  public string GetCardType() => "MoneyBack";
  public double GetCreditLimit() => 10000;
  public double GetAnnualCharge() => 500;
}
