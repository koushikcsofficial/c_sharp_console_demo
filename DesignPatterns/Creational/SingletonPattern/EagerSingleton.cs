namespace DesignPatterns.Creational.SingletonPattern;

public sealed class EagerSingleton
{
  // Private static instance created eagerly
  private static readonly EagerSingleton instance = new EagerSingleton();

  // Private constructor to prevent external instantiation
  private EagerSingleton() { }

  // Public static property to access the instance
  public static EagerSingleton Instance => instance;
}
