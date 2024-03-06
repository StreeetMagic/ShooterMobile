using Infrastructure.Utilities;

namespace Infrastructure.DataRepositories
{
  public class DataRepository
  {
    public ReactiveProperty<int> MoneyInBank { get; } = new();
    public ReactiveProperty<int> MoneyInBackpack { get; } = new();
    
    public ReactiveProperty<int> EggsInBank { get; } = new();
    public ReactiveProperty<int> EggsInBackpack { get; } = new();
  }
}