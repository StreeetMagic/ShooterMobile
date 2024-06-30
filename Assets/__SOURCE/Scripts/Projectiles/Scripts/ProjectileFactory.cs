using System;
using Gameplay.Characters.Enemies.Configs;
using Gameplay.Characters.Enemies.Projectiles;
using Gameplay.Characters.Players.Projectiles;
using Gameplay.Weapons;
using Infrastructure.ArtConfigServices;
using Infrastructure.AssetProviders;
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
    private readonly ArtConfigProvider _artConfigProvider;

    public ProjectileFactory(AssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory,
      VisualEffectFactory visualEffectFactory, ArtConfigProvider artConfigProvider)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
      _visualEffectFactory = visualEffectFactory;
      _artConfigProvider = artConfigProvider;
    }

    public void CreatePlayerProjectile(Transform parent, Vector3 rotation, WeaponTypeId weaponTypeId)
    {
      //PlayerProjectile playerProjectile = _zenjectFactory.InstantiateMono(prefab, parent.position, Quaternion.LookRotation(rotation), parent);
      PlayerProjectile playerProjectile = _zenjectFactory.InstantiateGameObject(PrefabId.PlayerProjectile, parent.position, Quaternion.LookRotation(rotation), parent).GetComponent<PlayerProjectile>();

      VisualEffectId bulletEffectId;

      switch (weaponTypeId)
      {
        case WeaponTypeId.Unknown:
        case WeaponTypeId.Knife:
          throw new ArgumentOutOfRangeException();

        case WeaponTypeId.DesertEagle:
          bulletEffectId = VisualEffectId.BulletYellow;
          break;

        case WeaponTypeId.Famas:
        case WeaponTypeId.Ak47:
          bulletEffectId = VisualEffectId.BulletYellow;
          break;

        case WeaponTypeId.Xm1014:
          bulletEffectId = VisualEffectId.BulletYellow;
          break;

        default:
          throw new ArgumentOutOfRangeException();
      }

      GameObject bulletEffectObject = _visualEffectFactory.Create(bulletEffectId, playerProjectile.transform.position, playerProjectile.transform);
      bulletEffectObject.transform.SetParent(playerProjectile.transform);

      playerProjectile.transform.SetParent(null);
    }

    public void CreateEnemyProjectile(Transform parent, Vector3 position, Vector3 rotation, EnemyConfig enemyConfig)
    {
//    EnemyProjectile enemyProjectile = _zenjectFactory.InstantiateMono(prefab, parent.position, Quaternion.LookRotation(rotation));
      EnemyProjectile enemyProjectile = _zenjectFactory.InstantiateGameObject(PrefabId.EnemyProjectile, parent.position, Quaternion.LookRotation(rotation), parent).GetComponent<EnemyProjectile>(); 
      enemyProjectile.EnemyConfig = enemyConfig;
      enemyProjectile.transform.SetParent(null);
      CreateEnemyBulletEffect(enemyProjectile.transform, enemyConfig);
    }

    private void CreateEnemyBulletEffect(Transform parent, EnemyConfig enemyConfig)
    {
      VisualEffectId id = _artConfigProvider.GetEnemyBulletEffectId(enemyConfig.Id);

      GameObject muzzleEffectObject = _visualEffectFactory.Create(id, parent.position, parent);

      muzzleEffectObject.transform.SetParent(parent);
    }
  }
}