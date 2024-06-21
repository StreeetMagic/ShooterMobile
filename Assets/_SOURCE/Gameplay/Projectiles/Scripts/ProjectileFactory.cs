using System;
using Gameplay.Characters.Enemies;
using Gameplay.Characters.Enemies.Configs;
using Gameplay.Characters.Enemies.Projectiles;
using Gameplay.Characters.Players;
using Gameplay.Characters.Players.Projectiles;
using Gameplay.Weapons;
using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
using Infrastructure.ConfigServices;
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
    private readonly VisualEffectFactory _visualEffectFactory;
    private readonly ConfigProvider _configProvider;
    private readonly PlayerProvider _playerProvider;
    private readonly ArtConfigProvider _artConfigProvider;
    private readonly VisualEffectProvider _visualEffectProvider;

    public ProjectileFactory(AssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory,
      VisualEffectFactory visualEffectFactory, ConfigProvider configProvider, PlayerProvider playerProvider,
      ArtConfigProvider artConfigProvider, VisualEffectProvider visualEffectProvider)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
      _visualEffectFactory = visualEffectFactory;
      _configProvider = configProvider;
      _playerProvider = playerProvider;
      _artConfigProvider = artConfigProvider;
      _visualEffectProvider = visualEffectProvider;
    }

    public void CreatePlayerProjectile(Transform parent, Vector3 rotation, WeaponTypeId weaponTypeId)
    {
      PlayerProjectile prefab = _assetProvider.Get<PlayerProjectile>();
      PlayerProjectile playerProjectile = _zenjectFactory.InstantiateMono(prefab, parent.position, Quaternion.LookRotation(rotation), parent);

      VisualEffectId bulletEffectId;

      switch (_playerProvider.Instance.WeaponIdProvider.CurrentId.Value)
      {
        case WeaponTypeId.Unknown:
        case WeaponTypeId.Knife:
          throw new ArgumentOutOfRangeException();

        case WeaponTypeId.DesertEagle:
          bulletEffectId = VisualEffectId.PistolBullet;
          break;

        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          bulletEffectId = VisualEffectId.RiffleBullet;
          break;

        case WeaponTypeId.Xm1014:
          bulletEffectId = VisualEffectId.ShotgunBullet;
          break;

        default:
          throw new ArgumentOutOfRangeException();
      }

      GameObject bulletEffectObject = _visualEffectFactory.Create(bulletEffectId, playerProjectile.transform.position, playerProjectile.transform);
      bulletEffectObject.transform.SetParent(playerProjectile.transform);

      playerProjectile.transform.SetParent(null);
      CreatePlayerMuzzleFlashEffect(parent, weaponTypeId);
    }

    public void CreateEnemyProjectile(Transform parent, Vector3 position, Vector3 rotation, EnemyConfig enemyConfig)
    {
      EnemyProjectile prefab = _assetProvider.Get<EnemyProjectile>();
      EnemyProjectile enemyProjectile = _zenjectFactory.InstantiateMono(prefab, parent.position, Quaternion.LookRotation(rotation), null);
      enemyProjectile.EnemyConfig = enemyConfig;
      enemyProjectile.transform.SetParent(null);
      CreateEnemyBulletEffect(enemyProjectile.transform, enemyConfig);

      _visualEffectFactory.CreateAndDestroy(_artConfigProvider.GetEnemyMuzzleFlashEffectId(enemyConfig.Id), position, parent);
    }

    private void CreateEnemyBulletEffect(Transform parent, EnemyConfig enemyConfig)
    {
      VisualEffectId id = _artConfigProvider.GetEnemyBulletEffectId(enemyConfig.Id);

      GameObject muzzleEffectObject = _visualEffectFactory.Create(id, parent.position, parent);

      muzzleEffectObject.transform.SetParent(parent);
    }

    private void CreatePlayerMuzzleFlashEffect(Transform parent, WeaponTypeId weaponTypeId)
    {
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

      _visualEffectFactory.CreateAndDestroy(id, parent.position, parent);
    }
  }
}