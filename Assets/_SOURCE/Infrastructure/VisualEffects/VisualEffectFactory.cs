using System;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.VisualEffects
{
  public class VisualEffectFactory
  {
    private readonly AssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _zenjectFactory;

    public VisualEffectFactory(AssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
    }

    public void Create(ParticleEffectId visualEffectId, Vector3 position, Transform parent, Transform target = null)
    {
      switch (visualEffectId)
      {
        case ParticleEffectId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(visualEffectId), visualEffectId, null);

        case ParticleEffectId.PlayerMuzzleFlash:
          GameObject muzzlePrefab1 = _assetProvider.Get("PlayerMuzzleFlash");
          GameObject muzzleFlash1 = _zenjectFactory.InstantiateGameObject(muzzlePrefab1, position, Quaternion.identity, parent);
          muzzleFlash1.transform.SetParent(null);
          float duration1 = muzzlePrefab1.GetComponentInChildren<ParticleSystem>().main.duration;
          Object.Destroy(muzzleFlash1, duration1);
          break;

        case ParticleEffectId.PlayerBulletImpact:
          GameObject impactPrefab2 = _assetProvider.Get("PlayerBulletImpact");
          GameObject impact2 = _zenjectFactory.InstantiateGameObject(impactPrefab2, position, Quaternion.identity, parent);
          impact2.transform.SetParent(null);
          float impactDuration2 = impactPrefab2.GetComponent<ParticleSystem>().main.duration;
          Object.Destroy(impact2, impactDuration2);
          break;
        
        case ParticleEffectId.EnemyMuzzleFlash:
          GameObject muzzlePrefab = _assetProvider.Get("EnemyMuzzleFlash");
          GameObject muzzleFlash = _zenjectFactory.InstantiateGameObject(muzzlePrefab, position, Quaternion.identity, parent);
          muzzleFlash.transform.SetParent(null);
          float duration = muzzlePrefab.GetComponentInChildren<ParticleSystem>().main.duration;
          Object.Destroy(muzzleFlash, duration);
          break;
        
        case ParticleEffectId.EnemyBulletImpact:
          GameObject impactPrefab = _assetProvider.Get("EnemyBulletImpact");
          GameObject impact = _zenjectFactory.InstantiateGameObject(impactPrefab, position, Quaternion.identity, parent);
          impact.transform.SetParent(null);
          float impactDuration = impactPrefab.GetComponentInChildren<ParticleSystem>().main.duration;
          Object.Destroy(impact, impactDuration);
          break;
        
        case ParticleEffectId.HenExplosion:
          GameObject explosionPrefab = _assetProvider.Get("HenExplosion");
          GameObject explosion = _zenjectFactory.InstantiateGameObject(explosionPrefab, position, Quaternion.identity, parent);
          explosion.transform.SetParent(null);
          float explosionDuration = explosionPrefab.GetComponent<ParticleSystem>().main.duration;
          Object.Destroy(explosion, explosionDuration);
          break;
      }
    }
  }
}