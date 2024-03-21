using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Gameplay.BaseTriggers
{
  public class BaseTriggerFactory
  {
    private readonly ZenjectFactory _factory;
    private readonly IAssetProvider _assetProvider;

    public BaseTriggerFactory(ZenjectFactory factory, IAssetProvider assetProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
    }

    public void Create(Transform parent)
    {
      BaseTrigger prefab = _assetProvider.Get<BaseTrigger>();
      BaseTrigger trigger = _factory.Instantiate(prefab, parent);

      trigger.transform.parent = null;
    }
  }
}