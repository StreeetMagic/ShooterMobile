using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Healths;
using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Gameplay.CorpseRemovers;
using Gameplay.RewardServices;
using Infrastructure.AssetProviders;
using Infrastructure.CoroutineRunners;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Spawners
{
  public class EnemyFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly RandomService _randomService;
    private readonly IStaticDataService _staticDataService;
    private readonly RewardService _rewardService;
    private readonly CorpseRemover _corpseRemover;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly EnemyLootSlotFactory _enemyLootSlotFactory;

    public EnemyFactory(IAssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory,
      RandomService randomService, IStaticDataService staticDataService, RewardService rewardService,
      CorpseRemover corpseRemover, ICoroutineRunner coroutineRunner, EnemyLootSlotFactory enemyLootSlotFactory)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
      _randomService = randomService;
      _staticDataService = staticDataService;
      _rewardService = rewardService;
      _corpseRemover = corpseRemover;
      _coroutineRunner = coroutineRunner;
      _enemyLootSlotFactory = enemyLootSlotFactory;
    }

    public Enemy Create(EnemyId id, Transform parent, Vector3 position, List<SpawnPoint> spawnPoints)
    {
      Enemy prefab = _assetProvider.ForEnemy(id);
      Enemy enemy = _zenjectFactory.InstantiateMono(prefab, position, Quaternion.identity, parent);
      enemy.Config = _staticDataService.GetEnemyConfig(id);

      var health = enemy.GetComponentInChildren<EnemyHealth>();

      _corpseRemover.Add(health);
      _rewardService.AddEnemy(health);

      enemy.GetComponentInChildren<EnemyMoverController>().Init(spawnPoints);

      Transform enemyLootSlotsContainer = enemy.GetComponentInChildren<EnemyLootSlotsContainer>().transform;
      _enemyLootSlotFactory.Create(enemyLootSlotsContainer, id);

      return enemy;
    }

    public void Destroy(Enemy enemy)
    {
      var moverController = enemy.GetComponentInChildren<EnemyMoverController>();

      if (moverController == null)
        return;

      moverController.Dispose();
    }
  }
}