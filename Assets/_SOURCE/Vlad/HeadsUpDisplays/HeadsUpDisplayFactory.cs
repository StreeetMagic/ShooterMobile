using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Vlad.HeadsUpDisplays
{
  public class HeadsUpDisplayFactory
  {
    private readonly IZenjectFactory _factory;
    private readonly IAssetProvider _assetProvider;
    private readonly HeadsUpDisplayProvider _provider;

    public HeadsUpDisplayFactory(IZenjectFactory factory,
      IAssetProvider assetProvider,
      HeadsUpDisplayProvider provider)
    {
      _factory = factory;
      _assetProvider = assetProvider;
      _provider = provider;
    }

    public void Create(Transform parent)
    {
      HeadsUpDisplayVlad prefab = _assetProvider.Get<HeadsUpDisplayVlad>();
      HeadsUpDisplayVlad display = _factory.Instantiate(prefab, parent);

      _provider.HeadsUpDisplayVlad = display;

      display.transform.parent = null;
    }
  }
}