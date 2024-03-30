using System.Collections.Generic;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies.Movers
{
  public class RoutePointsManager
  {
    private int _currentRouteIndex;
    private List<SpawnPoint> _routePoints;
    private Enemy _enemy;
    private bool _isInitialized;

    public RoutePointsManager(Enemy enemy)
    {
      _enemy = enemy;
    }

    public Transform NextRoutePointTransform
    {
      get
      {
        if (_isInitialized)
          return _routePoints[_currentRouteIndex].transform;

        Initialize();
        _isInitialized = true;

        return _routePoints[_currentRouteIndex].transform;
      }
    }

    private void Initialize()
    {
      List<SpawnPoint> componentsProviderSpawnPoints = _enemy.ComponentsProvider.SpawnPoints;

      _routePoints = ShuffleRoutePoints(componentsProviderSpawnPoints);

      SetRandomRoute();
    }

    public void SetRandomRoute()
    {
      if (!_isInitialized)
      {
        _isInitialized = true;
        Initialize();
      }

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