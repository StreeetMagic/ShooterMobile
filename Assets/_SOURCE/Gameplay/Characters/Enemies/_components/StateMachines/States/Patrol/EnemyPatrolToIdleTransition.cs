using System;
using Gameplay.Characters.Enemies.StateMachines.States.Idle;
using Gameplay.Characters.FiniteStateMachines;
using Gameplay.Characters.Players.StateMachines.States.IdleState;
using UnityEngine;

namespace Gameplay.Characters.Enemies.StateMachines.States.Patrol
{
  public class EnemyPatrolToIdleTransition : Transition
  {
    private const float DistanceToRoutePoint = 0.5f;

    private readonly EnemyRoutePointsManager _points;

    private readonly Transform _transform;

    public EnemyPatrolToIdleTransition(EnemyRoutePointsManager points,
      Transform transform)
    {
      _points = points;

      _transform = transform;
    }

    public override void Tick()
    {
      float distance = Vector3.Distance(_points.Next.position, _transform.position);

      if (distance < DistanceToRoutePoint)
        Enter<EnemyIdleState>();
    }
  }
}