using System;
using Infrastructure.AssetProviders;
using Infrastructure.Games;
using Infrastructure.ZenjectFactories;
using UnityEngine;

namespace Maps
{
  public class MapFactory
  {
    private readonly IZenjectFactory _zenjectFactory;
    private readonly IAssetProvider _assetProvider;
    private readonly MapProvider _mapProvider;

    public MapFactory(IZenjectFactory factory, IAssetProvider assetProvider, MapProvider mapProvider)
    {
      _zenjectFactory = factory;
      _assetProvider = assetProvider;
      _mapProvider = mapProvider;
    }

    public void Create(Transform parent)
    {
      _mapProvider.Map = _zenjectFactory.Instantiate(Behaviour(), parent);

      MoveToRootParent(_mapProvider.Map);
    }

    private void MoveToRootParent(Map map) =>
      map.transform.SetParent(null);

    private Map Behaviour() =>
      _assetProvider.Get<Map>(Constants.AssetsPath.Prefabs.Map);
  }
}