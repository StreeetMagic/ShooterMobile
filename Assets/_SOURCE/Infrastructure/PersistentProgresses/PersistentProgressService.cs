using Infrastructure.Utilities;

namespace Infrastructure.PersistentProgresses
{
  public class PersistentProgressService
  {
    public ReactiveProperty<int> MoneyInBank { get; } = new();
    public ReactiveProperty<int> MoneyInBackpack { get; } = new();

    public ReactiveProperty<int> EggsInBank { get; } = new();
    public ReactiveProperty<int> EggsInBackpack { get; } = new();
  }
}