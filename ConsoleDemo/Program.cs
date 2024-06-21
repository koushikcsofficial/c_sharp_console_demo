using ConsoleDemo.DesignPatterns.Creational.FactoryPattern;
using ConsoleDemo.DesignPatterns.Creational.SingletonPattern;
//using ConsoleDemo.DesignPatterns.Creational.FactoryMethodPattern;
using ConsoleDemo.DesignPatterns.Creational.AbstractFactory;
using ConsoleDemo.DesignPatterns.Creational.BuilderPattern;
using ConsoleDemo.DesignPatterns.Creational.PrototypePattern;
using ConsoleDemo.DesignPatterns.ComboPatterns.FactoryMethodAndObserver;
//using ConsoleDemo.DesignPatterns.Creational.FluentBuilderPattern;
using ConsoleDemo.ProgramingPractice;

#region Factory Design Pattern example
ICreditCardFactory factory = new PlatinumFactory(); // Change factory type as needed
ICreditCard card = factory.CreateCreditCard();

Console.WriteLine($"Card Type: {card.GetCardType()}");
Console.WriteLine($"Credit Limit: ${card.GetCreditLimit()}");
Console.WriteLine($"Annual Charge: ${card.GetAnnualCharge()}");
#endregion

#region  Factory method design pattern
/*
CreditCardFactory factory = new MoneyBackFactory(); // Change factory type as needed
ICreditCard card = factory.CreateCreditCard();

Console.WriteLine($"Card Type: {card.GetCardType()}");
Console.WriteLine($"Credit Limit: ${card.GetCreditLimit()}");
Console.WriteLine($"Annual Charge: ${card.GetAnnualCharge()}");
*/
#endregion

#region  Abstract factory design pattern
IVehicleFactory hondaFactory = new HondaFactory();
var hondaBike = hondaFactory.CreateBike();
var hondaCar = hondaFactory.CreateCar();

// Create a Toyota factory
IVehicleFactory toyotaFactory = new ToyotaFactory();
var toyotaBike = toyotaFactory.CreateBike();
var toyotaCar = toyotaFactory.CreateCar();

#endregion

#region Builder design pattern
var builder = new HawaiianPizzaBuilder();
var director = new Director(builder);

director.Construct();
var pizza = builder.GetResult();

Console.WriteLine($"Hawaiian Pizza: {pizza.PartA}, {pizza.PartB}");
#endregion

#region Fluent Builder Design pattern
/*
var employee = new FluentEmployee()
    .SetFirstName("John")
    .SetLastName("Doe")
    .SetAge(30)
    .Build();
*/
#endregion

#region Prototype design pattern
Employee emp1 = new Employee { Name = "John", Department = "HR" };
Employee emp2 = emp1; // Cloning emp1

emp2.Name = "Alice"; // Changes emp2's name, but emp1 remains unchanged

Console.WriteLine($"Employee 1: {emp1.Name}, {emp1.Department}");
Console.WriteLine($"Employee 2: {emp2.Name}, {emp2.Department}");
#endregion

#region Factory method with observer pattern
ReportManager manager = new ReportManager(new SalesReportFactory());

// Register observers (e.g., Email notification & Dashboard update)
IReportObserver notificationSystem = new ReportNotificationSystem();
IReportObserver dashboardUpdater = new DashboardUpdater();
manager.RegisterObserver(notificationSystem);
manager.RegisterObserver(dashboardUpdater);

// Generate a sales report
FinancialReport report = manager.GenerateReport("Sales");

// Example usage of the report
Console.WriteLine("Report Title: {report.Title}");
Console.WriteLine("Generated Date: {report.GeneratedDate}");
#endregion

#region NonRepeatCharacters program solution
Console.WriteLine(NonRepeatChatacters.solution("Koushik"));
#endregion