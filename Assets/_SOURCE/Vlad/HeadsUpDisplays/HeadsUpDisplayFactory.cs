using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Vlad.HeadsUpDisplays
{
  public class HeadsUpDisplayFactory
  {
    private IZenjectFactory _factory;
    private IAssetProvider _assetProvider;

    public HeadsUpDisplayFactory(IZenjectFactory factory, IAssetProvider assetProvider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
    }

    public void Create(Transform parent)
    {
      HeadsUpDisplayVlad prefab = _assetProvider.Get<HeadsUpDisplayVlad>();
      HeadsUpDisplayVlad display = _factory.Instantiate(prefab, parent);
      
      display.transform.parent = null;
    }
  }
}