using Infrastructure.ZenjectFactories.SceneContext;
using UnityAssetsTools.ParticleImage.Runtime;
using UnityEngine;

namespace Infrastructure.VisualEffects.ParticleImages
{
  public class ParticleImageFactory
  {
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly ParticleImageService _particleImageService;

    public ParticleImageFactory(GameLoopZenjectFactory zenjectFactory)
    {
      _zenjectFactory = zenjectFactory;
    }

    public ParticleImage Create(ParticleImageId visualEffectId, Vector3 position, Transform parent, Transform target = null, int amount = 0)
    {
      ParticleImage prefab = _particleImageService.GetPrefab(visualEffectId);
      GameObject moneyObject = _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, Quaternion.identity, parent);

      moneyObject.transform.SetParent(parent);

      prefab.main.attractorTarget = target;
      prefab.Play();

      return prefab;
    }
  }
}