using System;
using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.VisualEffects
{
  public class VisualEffectFactory
  {
    private readonly VisualEffectService _visualEffectService;
    private readonly GameLoopZenjectFactory _zenjectFactory;

    public VisualEffectFactory(GameLoopZenjectFactory zenjectFactory, VisualEffectService visualEffectService)
    {
      _zenjectFactory = zenjectFactory;
      _visualEffectService = visualEffectService;
    }

    public void Create(VisualEffectId visualEffectId, Vector3 position, Transform parent, Transform target = null)
    {
      ParticleSystem prefab = _visualEffectService.GetPrefab(visualEffectId);
      GameObject instance = _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, Quaternion.identity, parent);
      float duration = prefab.main.duration;
      Object.Destroy(instance, duration);
    }
  }
}