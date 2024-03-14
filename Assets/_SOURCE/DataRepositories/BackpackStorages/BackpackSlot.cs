using System;

namespace Infrastructure.DataRepositories
{
  [Serializable]
  public class BackpackSlot
  {
    public int Count;

    private LootConfig _lootConfig;
  }
}