using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityAssetsTools.ParticleImage.Runtime;
using UnityEngine;

namespace Infrastructure.VisualEffects
{
  public class ParticleImageFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly GameLoopZenjectFactory _zenjectFactory;

    public ParticleImageFactory(IAssetProvider assetProvider, GameLoopZenjectFactory zenjectFactory)
    {
      _assetProvider = assetProvider;
      _zenjectFactory = zenjectFactory;
    }

    public ParticleImage Create(ParticleImageId visualEffectId, Vector3 position, Transform parent, Transform target = null, int amount = 0)
    {
      switch (visualEffectId)
      {
        case ParticleImageId.MoneyCollection1:
          GameObject prefab = _assetProvider.Get(nameof(ParticleImageId.MoneyCollection1));
          GameObject moneyObject = _zenjectFactory.InstantiateGameObject(prefab, position, Quaternion.identity, parent);

          moneyObject.transform.SetParent(parent);

          var particleImage = moneyObject.GetComponent<ParticleImage>();

          particleImage.main.attractorTarget = target;

          particleImage.Play();

          return particleImage;

        case ParticleImageId.EggCollection1:
          GameObject prefab2 = _assetProvider.Get(nameof(ParticleImageId.EggCollection1));
          GameObject moneyObject2 = _zenjectFactory.InstantiateGameObject(prefab2, position, Quaternion.identity, parent);

          moneyObject2.transform.SetParent(parent);

          var particleImage2 = moneyObject2.GetComponent<ParticleImage>();

          particleImage2.main.attractorTarget = target;

          particleImage2.Play();

          return particleImage2;

        case ParticleImageId.MoneySender:

          GameObject prefab3 = _assetProvider.Get(nameof(ParticleImageId.MoneySender));
          GameObject moneyObject3 = _zenjectFactory.InstantiateGameObject(prefab3, position, Quaternion.identity, parent);

          moneyObject3.transform.SetParent(parent);

          var particleImage3 = moneyObject3.GetComponent<ParticleImage>();

          particleImage3.main.rateOverTime = amount;
          particleImage3.main.attractorTarget = target;
          particleImage3.Play();

          return particleImage3;

        case ParticleImageId.EggSender:
          
          GameObject prefab4 = _assetProvider.Get(nameof(ParticleImageId.EggSender));
          GameObject moneyObject4 = _zenjectFactory.InstantiateGameObject(prefab4, position, Quaternion.identity, parent);
          
          moneyObject4.transform.SetParent(parent);
          
          var particleImage4 = moneyObject4.GetComponent<ParticleImage>();
          
          particleImage4.main.rateOverTime = amount;
          particleImage4.main.attractorTarget = target;
          particleImage4.Play();
          
          return particleImage4;
      }

      return null;
    }
  }
}