using System.Collections.Generic;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies.Movers
{
  public class RoutePointsManager
  {
    private readonly Transform _transform;
    private int _currentRouteIndex;
    private List<SpawnPoint> _routePoints;

    public RoutePointsManager(Transform transform, Enemy enemy)
    {
      _transform = transform;

      _routePoints = ShuffleRoutePoints(enemy.ComponentsProvider.SpawnPoints);

      SetRandomRoute();
    }

    public Transform NextRoutePointTransform =>
      _routePoints[_currentRouteIndex].transform;

    public void SetRandomRoute()
    {
      int currentIndex = _currentRouteIndex;

      do
      {
        _currentRouteIndex = Random.Range(0, _routePoints.Count);
      } while (_currentRouteIndex == currentIndex);
    }

    private List<SpawnPoint> ShuffleRoutePoints(List<SpawnPoint> points)
    {
      var list = new List<SpawnPoint>(points);

      for (int i = 0; i < points.Count; i++)
      {
        int randIndex = Random.Range(i, list.Count);
        (list[randIndex], list[i]) = (list[i], list[randIndex]);
      }

      return list;
    }
  }
}