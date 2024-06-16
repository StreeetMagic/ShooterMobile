using Infrastructure.ZenjectFactories.SceneContext;
using UnityAssetsTools.ParticleImage.Runtime;
using UnityEngine;

namespace Infrastructure.VisualEffects.ParticleImages
{
  public class ParticleImageFactory
  {
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly ParticleImageService _particleImageService;

    public ParticleImageFactory(GameLoopZenjectFactory zenjectFactory, ParticleImageService particleImageService)
    {
      _zenjectFactory = zenjectFactory;
      _particleImageService = particleImageService;
    }

    public ParticleImage Create(ParticleImageId visualEffectId, Vector3 position, Transform parent, Transform target = null, int amount = 0)
    {
      ParticleImage prefab = _particleImageService.GetPrefab(visualEffectId);
      GameObject moneyObject = _zenjectFactory.InstantiateGameObject(prefab.gameObject, position, Quaternion.identity, parent);

      moneyObject.transform.SetParent(parent);
      
      var partImage = moneyObject.GetComponent<ParticleImage>();

      partImage.main.attractorTarget = target;
      partImage.Play();

      return partImage;
    }
  }
}