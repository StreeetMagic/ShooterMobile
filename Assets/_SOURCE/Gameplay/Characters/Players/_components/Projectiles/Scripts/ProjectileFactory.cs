using Configs.Resources.VisualEffectConfigs;
using Gameplay.Characters.Enemies.EnemyShooters.Projectiles;
using Infrastructure;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Gameplay.Characters.Players.Projectiles.Scripts
{
  public class ProjectileFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly RandomService _randomService;
    private readonly VisualEffectFactory _visualEffectFactory;

    public ProjectileFactory(IAssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory,
      RandomService randomService, VisualEffectFactory visualEffectFactory)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
      _randomService = randomService;
      _visualEffectFactory = visualEffectFactory;
    }

    public void CreatePlayerProjectile(Transform parent, Vector3 rotation)
    {
      string guid = _randomService.GetRandomUniqueId();
      PlayerProjectile prefab = _assetProvider.Get<PlayerProjectile>();
      PlayerProjectile playerProjectile = _zenjectFactory.InstantiateMono(prefab, parent.position, Quaternion.LookRotation(rotation), parent);
      playerProjectile.transform.SetParent(null);
      playerProjectile.Guid = guid;

      _visualEffectFactory.Create(ParticleEffectId.MuzzleFlash, parent.position, parent);
    }

    public void CreateEnemyProjectile(Transform parent, Vector3 position, Vector3 rotation)
    {
      string guid = _randomService.GetRandomUniqueId();
      EnemyProjectile prefab = _assetProvider.Get<EnemyProjectile>();
      EnemyProjectile playerProjectile = _zenjectFactory.InstantiateMono(prefab, parent.position, Quaternion.LookRotation(rotation), parent);
      playerProjectile.transform.SetParent(null);
      playerProjectile.Guid = guid;

      _visualEffectFactory.Create(ParticleEffectId.MuzzleFlash, position, parent);
    }
  }
}