using System;
using Infrastructure.AssetProviders;
using Infrastructure.Games;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Zenject;

namespace Maps
{
  public class MapFactory
  {
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly IAssetProvider _assetProvider;
    private readonly MapProvider _mapProvider;

    public MapFactory(GameLoopZenjectFactory factory, IAssetProvider assetProvider, MapProvider mapProvider)
    {
      _zenjectFactory = factory;
      _assetProvider = assetProvider;
      _mapProvider = mapProvider;
    }

    public void Create(Transform parent)
    {
      _mapProvider.Map = _zenjectFactory.InstantiateMono<Map>();

      MoveToRootParent(_mapProvider.Map);
    }

    private void MoveToRootParent(Map map) =>
      map.transform.SetParent(null);

    private Map Behaviour() =>
      _assetProvider.Get<Map>(Constants.AssetsPath.Prefabs.Map);
  }
}