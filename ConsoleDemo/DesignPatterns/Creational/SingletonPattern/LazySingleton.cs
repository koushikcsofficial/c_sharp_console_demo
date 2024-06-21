namespace ConsoleDemo.DesignPatterns.Creational.SingletonPattern;

public class LazySingleton
{
  private static readonly Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(() => new LazySingleton());
  private int _totalVotes = 0;

  private LazySingleton() { }

  public static LazySingleton Instance => _instance.Value;
}
