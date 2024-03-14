using System;
using Configs.Resources.VisualEffectConfigs;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

public class VisualEffectFactory
{
  private readonly IAssetProvider _assetProvider;
  private readonly IZenjectFactory _zenjectFactory;

  public VisualEffectFactory(IAssetProvider assetProvider, IZenjectFactory zenjectFactory)
  {
    _assetProvider = assetProvider;
    _zenjectFactory = zenjectFactory;
  }

  public void Create(VIsualEffectId visualEffectId, Vector3 position, Transform parent)
  {
    switch (visualEffectId)
    {
      case VIsualEffectId.Unknown:
        throw new ArgumentOutOfRangeException(nameof(visualEffectId), visualEffectId, null);

        break;

      case VIsualEffectId.MuzzleFlash:
        GameObject muzzleFlashEffect = _assetProvider.Get("MuzzleFlashRoundYellow");
        GameObject muzzleFlash = _zenjectFactory.InstantiateObject(muzzleFlashEffect, position, Quaternion.identity, parent);
        muzzleFlash.transform.SetParent(null);
        break;

      case VIsualEffectId.BulletImpact:
        GameObject bulletImpact = _assetProvider.Get("FatBulletExplosionYellow");
        GameObject impact = _zenjectFactory.InstantiateObject(bulletImpact, position, Quaternion.identity, parent);
        impact.transform.SetParent(null);
        break;
    }
  }
}