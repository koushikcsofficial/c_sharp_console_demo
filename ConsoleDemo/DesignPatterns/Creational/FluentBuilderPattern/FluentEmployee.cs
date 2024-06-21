namespace ConsoleDemo.DesignPatterns.Creational.FluentBuilderPattern;

public class FluentEmployee
{
  private readonly Employee _employee = new Employee();

  public FluentEmployee SetFirstName(string firstName)
  {
    _employee.FirstName = firstName;
    return this;
  }

  public FluentEmployee SetLastName(string lastName)
  {
    _employee.LastName = lastName;
    return this;
  }

  public FluentEmployee SetAge(int age)
  {
    _employee.Age = age;
    return this;
  }

  // Other methods for additional properties...

  public Employee Build()
  {
    return _employee;
  }
}