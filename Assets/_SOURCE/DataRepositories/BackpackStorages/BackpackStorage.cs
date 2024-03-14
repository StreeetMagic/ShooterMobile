using Infrastructure.Utilities;

namespace Infrastructure.DataRepositories
{
  public class BackpackStorage
  {
    public ReactiveList<BackpackSlot> Slots { get; } = new();
  }
}