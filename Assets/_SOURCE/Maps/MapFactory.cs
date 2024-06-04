using UnityEngine;

namespace Maps
{
  public class MapFactory
  {
    private readonly MapProvider _mapProvider;

    public MapFactory(MapProvider mapProvider)
    {
      _mapProvider = mapProvider;
    }

    public void Create(Transform parent, string mapName = "default")
    {
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