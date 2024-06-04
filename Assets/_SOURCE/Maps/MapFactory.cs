using Projects;
using UnityEngine;
using ZenjectFactories;
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

    public void Create(Transform parent, string mapName = "default")
    {
      switch (mapName)
      {
        case "default":
         // _mapProvider.Map = _zenjectFactory.InstantiateMono<Map>();
          break;
        
        case "simeon":
         // _mapProvider.Map = _zenjectFactory.InstantiateMono<Map>(ProjectConstants.AssetsPath.Prefabs.SimeonMap);
          break;
        
        case "vlad":
         // _mapProvider.Map = _zenjectFactory.InstantiateMono<Map>(ProjectConstants.AssetsPath.Prefabs.VladMap);
          break;
      }    

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