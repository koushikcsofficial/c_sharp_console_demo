namespace DesignPatterns.ComboPatterns.FactoryMethodAndObserver;

// Interface for report observers interested in generation updates
public interface IReportObserver
{
  void OnReportGenerated(FinancialReport report);
}

// Abstract class representing a financial report
public abstract class FinancialReport
{
  public string Title { get; set; }
  public DateTime GeneratedDate { get; private set; }
  public List<FinancialData> Data { get; private set; }

  public FinancialReport()
  {
    GeneratedDate = DateTime.Now;
    Data = new List<FinancialData>();
  }

  public abstract void GenerateData();
}

// Concrete data class for financial reports
public class FinancialData
{
  public string Category { get; set; }
  public decimal Amount { get; set; }
}

// Concrete report class - Sales Report (example)
public class SalesReport : FinancialReport
{
  public override void GenerateData()
  {
    // Implement logic to fetch and format sales data
    Data.Add(new FinancialData { Category = "Total Sales", Amount = 1000.00m });
    Data.Add(new FinancialData { Category = "Cost of Goods Sold", Amount = 500.00m });
    Console.WriteLine("Sales report data generated");
  }
}

// Concrete report class - Inventory Report (example)
public class InventoryReport : FinancialReport
{
  public override void GenerateData()
  {
    // Implement logic to fetch and format inventory data
    Data.Add(new FinancialData { Category = "Total Inventory Value", Amount = 2000.00m });
    Data.Add(new FinancialData { Category = "Low Stock Items", Amount = 5 });
    Console.WriteLine("Inventory report data generated");
  }
}

// Interface for report creation (Factory Method)
public interface IReportFactory
{
  FinancialReport CreateReport(string type);
}

// Concrete factory class for creating sales reports
public class SalesReportFactory : IReportFactory
{
  public FinancialReport CreateReport(string type)
  {
    if (type.ToLower() == "sales")
    {
      return new SalesReport();
    }
    else
    {
      throw new ArgumentException("Invalid report type");
    }
  }
}

// Concrete factory class for creating inventory reports
public class InventoryReportFactory : IReportFactory
{
  public FinancialReport CreateReport(string type)
  {
    if (type.ToLower() == "inventory")
    {
      return new InventoryReport();
    }
    else
    {
      throw new ArgumentException("Invalid report type");
    }
  }
}

// Class to manage report creation and notifications
public class ReportManager
{
  private List<IReportObserver> observers = new List<IReportObserver>();
  private IReportFactory factory;

  public ReportManager(IReportFactory factory)
  {
    this.factory = factory;
  }

  public FinancialReport GenerateReport(string type)
  {
    FinancialReport report = factory.CreateReport(type);
    report.GenerateData();
    NotifyObservers(report);
    return report;
  }

  public void RegisterObserver(IReportObserver observer)
  {
    observers.Add(observer);
  }

  public void UnregisterObserver(IReportObserver observer)
  {
    observers.Remove(observer);
  }

  private void NotifyObservers(FinancialReport report)
  {
    foreach (var observer in observers)
    {
      observer.OnReportGenerated(report);
    }
  }
}

// Observer class for sending report notification (example)
public class ReportNotificationSystem : IReportObserver
{
  public void OnReportGenerated(FinancialReport report)
  {
    Console.WriteLine("Sending email notification for report");
  }
}
// Observer class for updating dashboard \(example\)
public class DashboardUpdater : IReportObserver
{
  public void OnReportGenerated(FinancialReport report)
  {
    Console.WriteLine($"Updating dashboard with {report.Title} data");
  }
}