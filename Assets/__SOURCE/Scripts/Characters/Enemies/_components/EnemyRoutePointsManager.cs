using System.Collections.Generic;
using Spawners.SpawnPoints;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters.Enemies._components
{
  public class EnemyRoutePointsManager
  {
    private readonly List<SpawnPoint> _spawnPoints;

    private int _currentRouteIndex;

    public Transform Next => _spawnPoints[_currentRouteIndex].transform;

    private EnemyRoutePointsManager(List<SpawnPoint> initialSpawnPoints)
    {
      _spawnPoints = initialSpawnPoints;

      _spawnPoints = ShuffleRoutePoints(initialSpawnPoints);

      SetRandomRoute();
    }

    public void SetRandomRoute()
    {
      int currentIndex = _currentRouteIndex;

      do
      {
        _currentRouteIndex = Random.Range(0, _spawnPoints.Count);
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