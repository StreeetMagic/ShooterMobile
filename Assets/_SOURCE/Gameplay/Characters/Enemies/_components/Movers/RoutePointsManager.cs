using System;
using System.Collections.Generic;
using Gameplay.Characters.Enemies.Spawners.SpawnPoints;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Gameplay.Characters.Enemies.Movers
{
  public class RoutePointsManager : IFixedTickable
  {
    private Transform _transform;
    private List<SpawnPoint> _routePoints;
    private int _currentRouteIndex;

    public void Init(List<SpawnPoint> routePoints, Transform trans)
    {
      _routePoints = ShuffleRoutePoints(routePoints);
      _transform = trans;
    }

    public Vector3 TargetPosition =>
      _routePoints == null
        ? Vector3.zero
        : _routePoints[_currentRouteIndex].transform.position;

    public void FixedTick()
    {
      if (Vector3.Distance(_routePoints[_currentRouteIndex].transform.position, _transform.position) < 0.1f)
        SetRandomRoute();
    }

    private void SetRandomRoute()
    {
      _currentRouteIndex = Random.Range(0, _routePoints.Count);
    }

    private List<SpawnPoint> ShuffleRoutePoints(List<SpawnPoint> points)
    {
      for (int i = 0; i < points.Count; i++)
      {
        int randIndex = Random.Range(i, points.Count);
        (points[randIndex], points[i]) = (points[i], points[randIndex]);
      }

      return points;
    }

    public void Dispose()
    {
      _routePoints = null;
    }
  }
}