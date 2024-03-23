using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Gameplay.BaseTriggers
{
  public class BaseTriggerFactory
  {
    private readonly GameLoopZenjectFactory _factory;
    private readonly IAssetProvider _assetProvider;

    public BaseTriggerFactory(GameLoopZenjectFactory factory, IAssetProvider assetProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
    }

    public void Create(Transform parent)
    {
      BaseTrigger prefab = _assetProvider.Get<BaseTrigger>();
      BaseTrigger trigger = _factory.InstantiateMono(prefab, parent);

      trigger.transform.parent = null;
    }
  }
}