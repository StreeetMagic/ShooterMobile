using System.Collections.Generic;
using System.Linq;
using Characters.Players._components;
using Infrastructure.ConfigProviders;
using Infrastructure.Utilities;
using Loots;
using Stats;

namespace CurrencyRepositories.BackpackStorages
{
  public class BackpackStorage
  {
    private readonly ConfigProvider _configProvider;
    private readonly PlayerStatsProvider _playerStatsProvider;

    public BackpackStorage(ConfigProvider configProvider,
      PlayerStatsProvider playerStatsProvider)
    {
      _configProvider = configProvider;
      _playerStatsProvider = playerStatsProvider;
    }

    public bool IsFull => Volume >= _playerStatsProvider.GetStat(StatId.BackpackCapacity);
    public ReactiveList<LootDrop> LootDrops { get; } = new();

    public int Volume =>
      LootDrops
        .Value
        .Select(lootDrop => _configProvider.GetLootConfig(lootDrop.Id).Loots[lootDrop.Level - 1].Volume)
        .Sum();

    public void AddLoot(List<LootDrop> enemyConfigLootDrops)
    {
      foreach (LootDrop lootDrop in enemyConfigLootDrops)
        LootDrops.Add(lootDrop);
    }

    public void Clean()
    {
      LootDrops.Clear();
    }

    public Dictionary<CurrencyId, int> ReadLoot()
    {
      Dictionary<CurrencyId, int> loot = new();

      foreach (LootDrop lootDrop in LootDrops.Value)
      {
        LootConfig lootConfig = _configProvider.GetLootConfig(lootDrop.Id);
        int value = lootConfig.Loots[lootDrop.Level - 1].Value;

        if (loot.ContainsKey(lootDrop.Id))
          loot[lootDrop.Id] += value;
        else
          loot.Add(lootDrop.Id, value);
      }

      return loot;
    }
  }
}