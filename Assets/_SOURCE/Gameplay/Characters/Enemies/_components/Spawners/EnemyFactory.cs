using System.Collections.Generic;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Gameplay.CorpseRemovers;
using Gameplay.RewardServices;
using Infrastructure.AssetProviders;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Spawners
{
  public class EnemyFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly IStaticDataService _staticDataService;
    private readonly RewardService _rewardService;
    private readonly CorpseRemover _corpseRemover;
    private readonly EnemyLootSlotFactory _enemyLootSlotFactory;

    public EnemyFactory(IAssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory,
      IStaticDataService staticDataService, RewardService rewardService,
      CorpseRemover corpseRemover, EnemyLootSlotFactory enemyLootSlotFactory)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
      _staticDataService = staticDataService;
      _rewardService = rewardService;
      _corpseRemover = corpseRemover;
      _enemyLootSlotFactory = enemyLootSlotFactory;
    }

    public Enemy Create(EnemyId id, Transform parent, Vector3 position, List<SpawnPoint> spawnPoints)
    {
      Enemy prefab = _assetProvider.ForEnemy(id);
      Enemy enemy = _zenjectFactory.InstantiateMono(prefab, position, Quaternion.identity, parent);

      enemy.Config = _staticDataService.GetEnemyConfig(id);
      enemy.SpawnPoints = spawnPoints;

      var health = enemy.GetComponentInChildren<EnemyHealth>();
      _corpseRemover.Add(health);
      _rewardService.AddEnemy(health);

      Transform enemyLootSlotsContainer = enemy.GetComponentInChildren<EnemyLootSlotsContainer>().transform;
      _enemyLootSlotFactory.Create(enemyLootSlotsContainer, id);

      return enemy;
    }
  }
}