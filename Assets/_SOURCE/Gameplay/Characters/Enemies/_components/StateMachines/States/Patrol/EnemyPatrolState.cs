using System.Collections.Generic;
using Gameplay.Characters.FiniteStateMachines;

namespace Gameplay.Characters.Enemies.StateMachines.States.Patrol
{
  public class EnemyPatrolState : State
  {
    private readonly EnemyMover _mover;
    private readonly EnemyRoutePointsManager _points;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyConfig _config;

    public EnemyPatrolState(List<Transition> transitions, EnemyMover mover,
      EnemyAnimatorProvider animatorProvider, EnemyConfig config, 
      EnemyRoutePointsManager points)
      : base(transitions)
    {
      _mover = mover;
      _animatorProvider = animatorProvider;
      _config = config;
      _points = points;
    }

    public override void Enter()
    {
      _animatorProvider.Instance.PlayWalk();
      _points.SetRandomRoute();
      _mover.Move(_points.Next.position, _config.MoveSpeed);
    }

    public override void Exit()
    {
      _mover.Stop();
      _animatorProvider.Instance.StopWalk();
    }
  }
}