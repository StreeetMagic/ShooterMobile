using Infrastructure.Games;
using Infrastructure.ZenjectFactories;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Maps
{
  public class MapFactory
  {
    private readonly GameLoopZenjectFactory _zenjectFactory;
    private readonly MapProvider _mapProvider;

    public MapFactory(GameLoopZenjectFactory factory, MapProvider mapProvider)
    {
      _zenjectFactory = factory;
      _mapProvider = mapProvider;
    }

    public void Create(Transform parent, bool isTest = false)
    {
      _mapProvider.Map = isTest == false
        ? _zenjectFactory.InstantiateMono<Map>()
        : _zenjectFactory.InstantiateMono<Map>(ProjectConstants.AssetsPath.Prefabs.VladMap);

      MoveToRootParent(_mapProvider.Map);
    }

    public void Destroy()
    {
      if (_mapProvider.Map == null)
        return;

      Object.Destroy(_mapProvider.Map.gameObject);
      _mapProvider.Map = null;
    }

    private void MoveToRootParent(Map map) =>
      map.transform.SetParent(null);
  }
}