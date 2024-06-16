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
    private readonly VisualEffectService _visualEffectService;
    private readonly GameLoopZenjectFactory _zenjectFactory;

    public VisualEffectFactory(AssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory, VisualEffectService visualEffectService)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
      _visualEffectService = visualEffectService;
    }

    public void Create(VisualEffectId visualEffectId, Vector3 position, Transform parent, Transform target = null)
    {
      ParticleSystem prefab = _visualEffectService.GetPrefab(visualEffectId);

      switch (visualEffectId)
      {
        case VisualEffectId.Unknown:
          throw new ArgumentOutOfRangeException(nameof(visualEffectId), visualEffectId, null);

        case VisualEffectId.PlayerMuzzleFlash:
          GameObject muzzleFlash1 = _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, Quaternion.identity, parent);
          muzzleFlash1.transform.SetParent(null);
          float duration1 = prefab.main.duration;
          Object.Destroy(muzzleFlash1, duration1);
          break;

        case VisualEffectId.PlayerBulletImpact:
          GameObject impactPrefab2 = _assetProvider.Get("PlayerBulletImpact");
          GameObject impact2 = _zenjectFactory.InstantiateGameObject(impactPrefab2, position, Quaternion.identity, parent);
          impact2.transform.SetParent(null);
          float impactDuration2 = impactPrefab2.GetComponent<ParticleSystem>().main.duration;
          Object.Destroy(impact2, impactDuration2);
          break;

        case VisualEffectId.EnemyMuzzleFlash:
          GameObject muzzleFlash = _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, Quaternion.identity, parent);
          muzzleFlash.transform.SetParent(null);
          float duration = prefab.main.duration;
          Object.Destroy(muzzleFlash, duration);
          break;

        case VisualEffectId.EnemyBulletImpact:
          GameObject impact = _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, Quaternion.identity, parent);
          impact.transform.SetParent(null);
          float impactDuration = prefab.main.duration;
          Object.Destroy(impact, impactDuration);
          break;

        case VisualEffectId.HenExplosion:
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