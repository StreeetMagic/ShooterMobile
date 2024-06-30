using Characters.Enemies._components.StateMachines.States.Idle;
using Characters.FiniteStateMachines;
using UnityEngine;

namespace Characters.Enemies._components.StateMachines.States.Patrol
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