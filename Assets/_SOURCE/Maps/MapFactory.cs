using Games;
using Infrastructure.Services.AssetProviders;
using Infrastructure.Services.ZenjectFactory;
using UnityEngine;

namespace _SOURCE.Maps
{
  public class MapFactory
  {
    private readonly IZenjectFactory _zenjectFactory;
    private readonly IAssetProvider _assetProvider;

    public MapFactory(IZenjectFactory factory, IAssetProvider assetProvider)
    {
      _zenjectFactory = factory;
      _assetProvider = assetProvider;
    }
    
    public Map Map { get; private set; }

    public void Create(Transform parent)
    {
      Map = _zenjectFactory.Instantiate(Behaviour(), parent);

      MoveToRootParent(Map);
    }

    private void MoveToRootParent(Map map) =>
      map.transform.SetParent(null);

    private Map Behaviour() =>
      _assetProvider.Get<Map>(Constants.AssetsPath.Prefabs.Map);
  }
}