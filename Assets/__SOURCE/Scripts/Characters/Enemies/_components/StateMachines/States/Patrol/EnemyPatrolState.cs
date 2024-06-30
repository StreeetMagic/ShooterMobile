using System.Collections.Generic;
using Characters.Enemies.Configs;
using Characters.FiniteStateMachines;

namespace Characters.Enemies._components.StateMachines.States.Patrol
{
  public class EnemyPatrolState : State
  {
    private readonly EnemyMover _mover;
    private readonly EnemyRoutePointsManager _points;
    private readonly EnemyAnimatorProvider _animatorProvider;
    private readonly EnemyConfig _config;
    private readonly EnemyHealer _healer;

    public EnemyPatrolState(List<Transition> transitions, EnemyMover mover,
      EnemyAnimatorProvider animatorProvider, EnemyConfig config, 
      EnemyRoutePointsManager points, EnemyHealer healer)
      : base(transitions)
    {
      _mover = mover;
      _animatorProvider = animatorProvider;
      _config = config;
      _points = points;
      _healer = healer;
    }

    public override void Enter()
    {
      _animatorProvider.Instance.PlayWalk();
      _points.SetRandomRoute();
      _mover.Move(_points.Next.position, _config.MoveSpeed);
    }
    
    protected override void OnTick()
    {
      _healer.Heal();
    }

    public override void Exit()
    {
      _mover.Stop();
      _animatorProvider.Instance.StopWalk();
      _healer.Heal();
    }
  }
}