using System.Collections.Generic;
using System.Linq;
using Gameplay.Currencies;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using UnityEngine;

namespace Infrastructure.DataRepositories
{
  public class BackpackStorage
  {
    private IStaticDataService _staticDataService;

    public BackpackStorage(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    public ReactiveList<LootDrop> LootDrops { get; } = new();

    public void AddLoot(List<LootDrop> enemyConfigLootDrops)
    {
      foreach (LootDrop lootDrop in enemyConfigLootDrops)
        LootDrops.Value.Add(lootDrop);

      Debug.Log(Info());
    }

    private string Info()
    {
      Dictionary<CurrencyId, int> loot = new Dictionary<CurrencyId, int>();

      foreach (LootDrop lootDrop in LootDrops.Value)
      {
        LootConfig lootConfig = _staticDataService.GetLootConfig(lootDrop.Id);
        int value = lootConfig.Loots[lootDrop.Level - 1].Value;

        if (loot.TryAdd(lootDrop.Id, value) == false)
          loot[lootDrop.Id] += value;
      }

      return
        loot
          .Aggregate(string.Empty, (current, kvp) => current + $"Currency: {kvp.Key}, Value: {kvp.Value}\n");
    }
  }
}