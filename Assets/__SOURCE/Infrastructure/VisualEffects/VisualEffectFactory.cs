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

    public void CreateAndDestroy(VisualEffectId visualEffectId, Vector3 position, Quaternion rotation)
    {
      ParticleSystem prefab = _visualEffectProvider.GetPrefab(visualEffectId);
      GameObject instance = _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, rotation, null);

      float duration = prefab.main.duration;

      Object.Destroy(instance, duration);
    }
    
    public void CreateAndDestroy(VisualEffectId visualEffectId, Vector3 position, Quaternion rotation, float scale)
    {
      ParticleSystem prefab = _visualEffectProvider.GetPrefab(visualEffectId);
      GameObject instance = _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, rotation, null);

      instance.transform.localScale = new Vector3(scale, scale, scale);

      float duration = prefab.main.duration;

      Object.Destroy(instance, duration);
    }

    public GameObject Create(VisualEffectId visualEffectId, Vector3 position, Transform parent, Transform target = null)
    {
      ParticleSystem prefab = _visualEffectProvider.GetPrefab(visualEffectId);
      return _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, Quaternion.identity, null);
    }
  }
}