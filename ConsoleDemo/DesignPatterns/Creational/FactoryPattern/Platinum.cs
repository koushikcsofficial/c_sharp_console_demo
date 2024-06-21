namespace ConsoleDemo.DesignPatterns.Creational.FactoryPattern;

class Platinum : ICreditCard
{
  public string GetCardType() => "Platinum";
  public double GetCreditLimit() => 50000;
  public double GetAnnualCharge() => 2000;
}