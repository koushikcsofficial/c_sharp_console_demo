namespace DesignPatterns.Creational.FactoryPattern;

class Titanium : ICreditCard
{
  public string GetCardType() => "Titanium";
  public double GetCreditLimit() => 20000;
  public double GetAnnualCharge() => 1000;
}