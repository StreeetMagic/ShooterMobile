using System.Collections.Generic;
using System.Linq;
using Configs.Resources.CurrencyConfigs;
using Configs.Resources.EnemyConfigs.Scripts;
using Configs.Resources.LootConfigs;
using Configs.Resources.StatConfigs;
using Gameplay.Characters.Players._components.PlayerStatsProviders;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;

namespace DataRepositories.BackpackStorages
{
  public class BackpackStorage
  {
    private readonly IStaticDataService _staticDataService;
    private readonly PlayerStatsProvider _playerStatsProvider;
    private readonly SaveLoadService _saveLoadService;

    public BackpackStorage(IStaticDataService staticDataService,
      PlayerStatsProvider playerStatsProvider, SaveLoadService saveLoadService)
    {
      _staticDataService = staticDataService;
      _playerStatsProvider = playerStatsProvider;
      _saveLoadService = saveLoadService;
    }

    public bool IsFull => Volume >= _playerStatsProvider.GetStat(StatId.BackpackCapacity).Value;
    public ReactiveList<LootDrop> LootDrops { get; } = new();

    public int Volume =>
      LootDrops
        .Value
        .Select(lootDrop => _staticDataService.GetLootConfig(lootDrop.Id).Loots[lootDrop.Level - 1].Volume)
        .Sum();

    public void AddLoot(List<LootDrop> enemyConfigLootDrops)
    {
      foreach (LootDrop lootDrop in enemyConfigLootDrops)
        LootDrops.Add(lootDrop);
    }

    public void Clean()
    {
      LootDrops.Clear();

      _saveLoadService.SaveProgress();
    }

    public Dictionary<CurrencyId, int> ReadLoot()
    {
      Dictionary<CurrencyId, int> loot = new();

      foreach (LootDrop lootDrop in LootDrops.Value)
      {
        LootConfig lootConfig = _staticDataService.GetLootConfig(lootDrop.Id);
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