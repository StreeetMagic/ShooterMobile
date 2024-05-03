using System;
using Configs.Resources.VisualEffectConfigs;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure
{
  public class VisualEffectFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _zenjectFactory;

    public VisualEffectFactory(IAssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory)
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

        case ParticleEffectId.MuzzleFlash:
          GameObject muzzlePrefab = _assetProvider.Get("MuzzleFlashRoundYellow");
          GameObject muzzleFlash = _zenjectFactory.InstantiateGameObject(muzzlePrefab, position, Quaternion.identity, parent);
          muzzleFlash.transform.SetParent(null);
          float duration = muzzlePrefab.GetComponent<ParticleSystem>().main.duration;
          Object.Destroy(muzzleFlash, duration);
          break;

        case ParticleEffectId.BulletImpact:
          GameObject impactPrefab = _assetProvider.Get("FatBulletExplosionYellow");
          GameObject impact = _zenjectFactory.InstantiateGameObject(impactPrefab, position, Quaternion.identity, parent);
          impact.transform.SetParent(null);
          float impactDuration = impactPrefab.GetComponent<ParticleSystem>().main.duration;
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