using Infrastructure.AssetProviders;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace UserInterface.HeadsUpDisplays
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
      HeadsUpDisplay prefab = _assetProvider.Get<HeadsUpDisplay>();
      HeadsUpDisplay display = _factory.Instantiate(prefab, parent);

      _provider.HeadsUpDisplay = display;

      display.transform.parent = null;
    }
  }
}