using System;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Configs;
using Gameplay.Characters.Enemies.Projectiles;
using Gameplay.Characters.Players.Projectiles;
using Gameplay.Weapons;
using Infrastructure.AssetProviders;
using Infrastructure.RandomServices;
using Infrastructure.VisualEffects;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;

namespace Gameplay.Projectiles.Scripts
{
  public class ProjectileFactory
  {
    private readonly AssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly RandomService _randomService;
    private readonly VisualEffectFactory _visualEffectFactory;

    public ProjectileFactory(AssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory,
      RandomService randomService, VisualEffectFactory visualEffectFactory)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
      _randomService = randomService;
      _visualEffectFactory = visualEffectFactory;
    }

    public void CreatePlayerProjectile(Transform parent, Vector3 rotation, WeaponTypeId weaponTypeId)
    {
      string guid = _randomService.GetRandomUniqueId();
      PlayerProjectile prefab = _assetProvider.Get<PlayerProjectile>();
      PlayerProjectile playerProjectile = _zenjectFactory.InstantiateMono(prefab, parent.position, Quaternion.LookRotation(rotation), parent);
      playerProjectile.transform.SetParent(null);
      playerProjectile.Guid = guid;

      VisualEffectId id;

      switch (weaponTypeId)
      {
        case WeaponTypeId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(weaponTypeId), weaponTypeId, null);

        case WeaponTypeId.DesertEagle:
          id = VisualEffectId.PistolMuzzleFlash;
          break;

        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          id = VisualEffectId.RiffleMuzzleFlash;
          break;

        case WeaponTypeId.Xm1014:
          id = VisualEffectId.ShotgunMuzzleFlash;
          break;

        default:
          throw new ArgumentOutOfRangeException(nameof(weaponTypeId), weaponTypeId, null);
      }

      _visualEffectFactory.Create(id, parent.position, parent);
    }

    public void CreateEnemyProjectile(Transform parent, Vector3 position, Vector3 rotation, EnemyConfig enemyConfig)
    {
      EnemyProjectile prefab = _assetProvider.Get<EnemyProjectile>();
      EnemyProjectile enemyProjectile = _zenjectFactory.InstantiateMono(prefab, parent.position, Quaternion.LookRotation(rotation), null);
      enemyProjectile.EnemyConfig = enemyConfig;
      enemyProjectile.transform.SetParent(null);

      _visualEffectFactory.Create(VisualEffectId.EnemyMuzzleFlash, position, parent);
    }
  }
}