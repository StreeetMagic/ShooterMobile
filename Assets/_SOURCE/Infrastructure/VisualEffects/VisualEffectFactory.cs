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
      GameObject instance = _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, Quaternion.identity, parent);
     // instance.transform.SetParent(null);
      float duration1 = prefab.main.duration;
      Object.Destroy(instance, duration1);
    }
  }
}