using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Vlad.BaseTriggers
{
  public class BaseTriggerFactory
  {
    private readonly IZenjectFactory _factory;
    private readonly IAssetProvider _assetProvider;

    public BaseTriggerFactory(IZenjectFactory factory, IAssetProvider assetProvider)
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