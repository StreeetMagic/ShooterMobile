using Configs.Resources.ParticleImageConfigs;
using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityAssetsTools.ParticleImage.Runtime;
using UnityEngine;

namespace Infrastructure
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

    public ParticleImage Create(ParticleImageId visualEffectId, Vector3 position, Transform parent, Transform target = null)
    {
      switch (visualEffectId)
      {
        case ParticleImageId.MoneyCollection1:
          GameObject moneyCollection = _assetProvider.Get(nameof(ParticleImageId.MoneyCollection1));
          GameObject money = _zenjectFactory.InstantiateGameObject(moneyCollection, position, Quaternion.identity, parent);

          money.transform.SetParent(parent);

          var particleImage = moneyCollection.GetComponent<ParticleImage>();

          particleImage.main.attractorTarget = target;
          float moneyDuration = particleImage.main.lifetime.constantMax;
          
          Debug.Log("Money duration: " + moneyDuration);
          
          particleImage.main.Play();

          //Object.Destroy(money, moneyDuration);

          return particleImage;
      }

      return null;
    }
  }
}