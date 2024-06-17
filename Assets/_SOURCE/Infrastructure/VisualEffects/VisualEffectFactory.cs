using Infrastructure.ZenjectFactories.SceneContext;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.VisualEffects
{
  public class VisualEffectFactory
  {
    private readonly VisualEffectProvider _visualEffectProvider;
    private readonly GameLoopZenjectFactory _zenjectFactory;

    public VisualEffectFactory(GameLoopZenjectFactory zenjectFactory, VisualEffectProvider visualEffectProvider)
    {
      _zenjectFactory = zenjectFactory;
      _visualEffectProvider = visualEffectProvider;
    }

    public void Create(VisualEffectId visualEffectId, Vector3 position, Transform parent, Transform target = null)
    {
      ParticleSystem prefab = _visualEffectProvider.GetPrefab(visualEffectId);
      GameObject instance = _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, Quaternion.identity, parent);
      float duration = prefab.main.duration;
      Object.Destroy(instance, duration);
    }
  }
}