using System.Collections.Generic;
using System.Linq;
using Gameplay.Characters.Players._components.PlayerStatsServices;
using Gameplay.Currencies;
using Infrastructure.StaticDataServices;
using Infrastructure.Utilities;

namespace Infrastructure.DataRepositories
{
  public class BackpackStorage
  {
    private readonly IStaticDataService _staticDataService;
    private readonly PlayerStatsProvider _playerStatsProvider;

    public BackpackStorage(IStaticDataService staticDataService, PlayerStatsProvider playerStatsProvider)
    {
      _staticDataService = staticDataService;
      _playerStatsProvider = playerStatsProvider;
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

    public Dictionary<LootDrop, int> Info()
    {
      Dictionary<LootDrop, int> loot = new Dictionary<LootDrop, int>();

      foreach (LootDrop lootDrop in LootDrops.Value)
      {
        LootConfig lootConfig = _staticDataService.GetLootConfig(lootDrop.Id);
        int value = lootConfig.Loots[lootDrop.Level - 1].Value;

        if (!loot.ContainsKey(lootDrop))
          loot.Add(lootDrop, value);

        loot[lootDrop] += value;
      }
      
      return loot;
    }
  }
}