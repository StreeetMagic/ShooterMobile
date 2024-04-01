using System;
using Gameplay.Characters.Enemies.Movers;
using UnityEngine;
using Zenject;

namespace Gameplay.Characters.Enemies
{
  public class EnemyMoverToSpawnPoint : MonoBehaviour
  {
    private EnemyMover _mover;
    private RoutePointsManager _routePointsManager;
    private Enemy _enemy;

    [Inject]
    public void Construct(EnemyMover mover, RoutePointsManager routePointsManager, Enemy enemy)
    {
      _mover = mover;
      _routePointsManager = routePointsManager;
      _enemy = enemy;
    }
    
    private float MoveSpeed => _enemy.Config.MoveSpeed;

    private void FixedUpdate()
    {
      var direction = (_routePointsManager.NextRoutePointTransform.position - transform.position).normalized;

      _mover.Move(direction, MoveSpeed);
    }
  }
}