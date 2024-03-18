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

    public bool IsFull => LootDrops.Value.Count >= _playerStatsProvider.BackpackCapacity.Value;
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

      string result = string.Empty;

      foreach (KeyValuePair<CurrencyId, int> i in loot)
        result += $"Currency: {i.Key}, Value: {i.Value}\n";

      return result;
    }
  }
}