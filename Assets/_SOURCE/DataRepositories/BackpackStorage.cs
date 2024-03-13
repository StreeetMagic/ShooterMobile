using System;
using Infrastructure.Utilities;

namespace Infrastructure.DataRepositories
{
  public class BackpackStorage
  {
    public ReactiveList<BackpackSlot> Slots { get; } = new();
  }

  [Serializable]
  public class BackpackSlot
  {
    public int Level;

    private LootConfig _lootConfig;
  }

  [Serializable]
  public class LootValue
  {
    public int Level;
    public int Volume;
    public int Value;
  }
}