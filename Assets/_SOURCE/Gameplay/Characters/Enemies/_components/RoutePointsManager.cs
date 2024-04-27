using System.Collections.Generic;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies
{
  public class RoutePointsManager : MonoBehaviour
  {
    private int _currentRouteIndex;

    [Inject] private List<SpawnPoint> _spawnPoints;

    public Transform NextRoutePointTransform => _spawnPoints[_currentRouteIndex].transform;

    private void Start()
    {
      Initialize();
    }

    private void Initialize()
    {
      List<SpawnPoint> componentsProviderSpawnPoints = _spawnPoints;

      _spawnPoints = ShuffleRoutePoints(componentsProviderSpawnPoints);

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