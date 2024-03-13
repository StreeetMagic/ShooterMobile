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
    public LootId LootId;
    public int Level;
    
    private LootConfig _lootConfig;
  }

  internal class LootConfig
  {
  }

  public enum LootId
  {
    Unknown,
    Money,
    Egg
  }
}