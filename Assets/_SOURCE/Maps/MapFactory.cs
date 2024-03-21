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
    private readonly ZenjectFactory _zenjectFactory;
    private readonly IAssetProvider _assetProvider;
    private readonly MapProvider _mapProvider;
    private readonly IInstantiator _instantiator;

    public MapFactory(ZenjectFactory factory, IAssetProvider assetProvider, MapProvider mapProvider, IInstantiator instantiator)
    {
      _zenjectFactory = factory;
      _assetProvider = assetProvider;
      _mapProvider = mapProvider;
      _instantiator = instantiator;
    }

    public void Create(Transform parent)
    {
      _mapProvider.Map = _zenjectFactory.Instantiate<Map>();
      // _mapProvider.Map = _instantiator.InstantiatePrefab(Behaviour(), parent).GetComponent<Map>();

      MoveToRootParent(_mapProvider.Map);
    }

    private void MoveToRootParent(Map map) =>
      map.transform.SetParent(null);

    private Map Behaviour() =>
      _assetProvider.Get<Map>(Constants.AssetsPath.Prefabs.Map);
  }
}