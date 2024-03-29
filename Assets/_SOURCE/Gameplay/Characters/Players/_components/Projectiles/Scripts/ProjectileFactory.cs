using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Enemies.Spawners;
using Gameplay.Characters.Players.Shooters.Projectiles;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

public class ProjectileFactory
{
  private readonly IAssetProvider _assetProvider;
  private readonly GameLoopZenjectFactory _zenjectFactory;
  private readonly RandomService _randomService;
  private readonly ProjectileStorage _projectileStorage;
  private readonly VisualEffectFactory _visualEffectFactory;

  public ProjectileFactory(IAssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory,
    RandomService randomService, ProjectileStorage projectileStorage, VisualEffectFactory visualEffectFactory)
  {
    _assetProvider = assetProvider;
    _zenjectFactory = zenjectFactory;
    _randomService = randomService;
    _projectileStorage = projectileStorage;
    _visualEffectFactory = visualEffectFactory;
  }

  public void CreatePlayerProjectile(Transform parent, Vector3 rotation)
  {
    string guid = _randomService.GetRandomUniqueId();
    PlayerProjectile prefab = _assetProvider.Get<PlayerProjectile>();
    PlayerProjectile playerProjectile = _zenjectFactory.InstantiateMono(prefab, parent.position, Quaternion.LookRotation(rotation), parent);
    playerProjectile.transform.SetParent(null);
    playerProjectile.Guid = guid;

    _visualEffectFactory.Create(VIsualEffectId.MuzzleFlash, parent.position, parent);
  }

  public void CreateEnemyProjectile(Transform parent, Vector3 rotation)
  {
    string guid = _randomService.GetRandomUniqueId();
    EnemyProjectile prefab = _assetProvider.Get<EnemyProjectile>();
    EnemyProjectile playerProjectile = _zenjectFactory.InstantiateMono(prefab, parent.position, Quaternion.LookRotation(rotation), parent);
    playerProjectile.transform.SetParent(null);
    playerProjectile.Guid = guid;

    _visualEffectFactory.Create(VIsualEffectId.MuzzleFlash, parent.position, parent);
  }
}