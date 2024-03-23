using System.Collections.Generic;
using System.Linq;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Gameplay.Currencies;
using Infrastructure.SaveLoadServices;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;
using UnityEngine;

namespace Infrastructure.DataRepositories
{
  public class BackpackStorage
  {
    private readonly IStaticDataService _staticDataService;
    private readonly PlayerStatsProvider _playerStatsProvider;
    private SaveLoadService _saveLoadService;

    public BackpackStorage(IStaticDataService staticDataService, PlayerStatsProvider playerStatsProvider, SaveLoadService saveLoadService)
    {
      _staticDataService = staticDataService;
      _playerStatsProvider = playerStatsProvider;
      _saveLoadService = saveLoadService;
    }

    public bool IsFull => Volume >= _playerStatsProvider.BackpackCapacity.Value;
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