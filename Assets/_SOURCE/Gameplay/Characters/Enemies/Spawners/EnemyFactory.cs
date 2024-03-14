using System.Collections.Generic;
using Configs.Resources.EnemyConfigs.Scripts;
using Gameplay.Characters.Enemies.Movers;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using Gameplay.Characters.Healths;
using Infrastructure.AssetProviders;
using Infrastructure.StaticDataServices;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Gameplay.Characters.Enemies.Spawners
{
  public class EnemyFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IZenjectFactory _zenjectFactory;
    private readonly RandomService _randomService;
    private readonly IStaticDataService _staticDataService;

    public EnemyFactory(IAssetProvider assetProvider, IZenjectFactory zenjectFactory,
      RandomService randomService, IStaticDataService staticDataService)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
      _randomService = randomService;
      _staticDataService = staticDataService;
    }

    public void Create(EnemyId id, Transform parent, Vector3 position, List<SpawnPoint> spawnPoints)
    {
      Enemy prefab = _assetProvider.ForEnemy(id);
      Enemy enemy = _zenjectFactory.Instantiate(prefab, position, Quaternion.identity, parent);
      
      EnemyConfig enemyConfig = _staticDataService.ForEnemy(id);

      var animator = enemy.GetComponentInChildren<EnemyAnimator>();

      var health = enemy.GetComponentInChildren<Health>();
      health.Init(enemyConfig, animator);

      enemy.GetComponentInChildren<EnemyMover>().Init(enemyConfig, spawnPoints, health);
    }
  }
}