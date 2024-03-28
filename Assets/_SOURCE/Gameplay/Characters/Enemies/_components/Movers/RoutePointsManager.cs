using System;
using System.Collections.Generic;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies.Movers
{
  public class RoutePointsManager
  {
    private readonly Transform _transform;
    private readonly Enemy _enemy;
    private int _currentRouteIndex;

    public RoutePointsManager(Transform transform, Enemy enemy)
    {
      _transform = transform;
      _enemy = enemy;
    }

    private List<SpawnPoint> RoutePoints => ShuffleRoutePoints(_enemy.SpawnPoints);

    public Transform NextRoutePointTransform =>
      RoutePoints?[_currentRouteIndex].transform;
    
    public float DistanceToNextRoutePoint =>
      Vector3.Distance(RoutePoints[_currentRouteIndex].transform.position, _transform.position);
    
    public Vector3 DirectionToNextRoutePoint =>
      (RoutePoints[_currentRouteIndex].transform.position - _transform.position).normalized;

    public void SetRandomRoute()
    {
      while (Vector3.Distance(RoutePoints[_currentRouteIndex].transform.position, _transform.position) < 0.1f)
        _currentRouteIndex = Random.Range(0, RoutePoints.Count);
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